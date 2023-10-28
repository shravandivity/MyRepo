using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagerMvc.ServiceContracts;
using TaskManagerMvc.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]LoginViewModel loginViewModel)
        {
            var user = await _userService.Authenticate(loginViewModel);
            if (user == null)
                return BadRequest(new {message = "Username or password is incorrect"});
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] SignUpViewModel signUpViewModel)
        {
            var user = await _userService.Register(signUpViewModel);
            if (user == null)
                return BadRequest(new { message = "Invalid data" });
            return Ok(user);
        }

        [HttpGet("getUserByEmail/{Email}")]
        public async Task<IActionResult> GetUserByEmail(string Email)
        {
            var user = await _userService.GetUserByEmail(Email);
            
            return Ok(user);
        }
    }
}

