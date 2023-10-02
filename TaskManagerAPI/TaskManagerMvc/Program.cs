using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagerMvc.Data;
using TaskManagerMvc.Identity;
using TaskManagerMvc.ServiceContracts;
using TaskManagerMvc.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using TaskManagerMvc;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(
     options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
builder.Services.AddTransient<UserManager<ApplicationUser>, ApplicationUserManager>();
builder.Services.AddTransient<SignInManager<ApplicationUser>, ApplicationSignInManager>();
builder.Services.AddTransient<RoleManager<ApplicationRole>, ApplicationRoleManager>();
builder.Services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserStore<ApplicationUserStore>()
    .AddUserManager<ApplicationUserManager>()
    .AddRoleManager<ApplicationRoleManager>()
    .AddSignInManager<ApplicationSignInManager>()
    .AddRoleStore<ApplicationRoleStore>()
    .AddDefaultTokenProviders();
    

builder.Services.AddScoped<ApplicationRoleStore>();
builder.Services.AddScoped<ApplicationUserStore>();

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = System.Text.Encoding.ASCII.GetBytes(appSettings.Key);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:key"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

IServiceScopeFactory serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using (var scope = serviceScopeFactory.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    //Create Admin Role
    if(!await roleManager.RoleExistsAsync("Admin"))
    {
        var role = new ApplicationRole();
        role.Name = "Admin";
        role.Id = Guid.NewGuid().ToString();
        role.NormalizedName = "ADMIN";
        await roleManager.CreateAsync(role);
    }

    //Create Employee Role
    if (!await roleManager.RoleExistsAsync("Employee"))
    {
        var role = new ApplicationRole();
        role.Name = "Employee";
        role.Id = Guid.NewGuid().ToString();
        await roleManager.CreateAsync(role);
    }

    //Create Admin user
    if (await userManager.FindByNameAsync("admin") == null)
    {
        var user = new ApplicationUser();
        user.UserName = "admin";
        user.Email = "admin@gmail.com";
        user.Id = Guid.NewGuid().ToString();
        var userPassword = "Admin123#";
        var chkUser = await userManager.CreateAsync(user, userPassword);
        var role = await roleManager.RoleExistsAsync("Admin");
        if (chkUser.Succeeded)
        {
            if (!await userManager.IsInRoleAsync(user, "Admin"))
            {
                var result = await userManager.AddToRoleAsync(user, "Admin");
            }
                
        }
            //await userManager.AddToRoleAsync(user, "Admin");
    }

    //Create Employee user
    if (await userManager.FindByNameAsync("Employee") == null)
    {
        var user = new ApplicationUser();
        user.UserName = "Employee";
        user.Email = "employee@gmail.com";
        user.Id = Guid.NewGuid().ToString();
        var userPassword = "Employee123#";
        var chkUser = await userManager.CreateAsync(user, userPassword);
        var role = await roleManager.RoleExistsAsync("Employee");
        if (chkUser.Succeeded)
        {
            if (!await userManager.IsInRoleAsync(user, "Employee"))
            {
                var result = await userManager.AddToRoleAsync(user, "Employee");
            }

        }
        //await userManager.AddToRoleAsync(user, "Admin");
    }



}

app.Run();

