using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI_Service.DTOs;
using SchoolAPI_Service.Model;
using SchoolAPI_Service.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        protected APIResponse _apiResponse;
        private readonly ITokenRepository _tokenRepository;
        protected LoginResponseDto _loginResponseDto;
        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            this._apiResponse = new ();
            _tokenRepository = tokenRepository;
            this._loginResponseDto = new();
            this._loginResponseDto.User = new();
        }

        // POST api/values
        [HttpPost("Register")]
        public async Task<ActionResult<APIResponse>> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            try
            {
                var identityUser = new IdentityUser { UserName = registerRequestDto.UserName, Email = registerRequestDto.UserName };
                var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);
                if (identityResult.Succeeded)
                {
                    //Add Roles to this user
                    if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                        identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        _apiResponse.Result = "User was registered! Please login.";
                        _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        _apiResponse.Result = "Something went wrong.";
                        _apiResponse.IsSuccess = false;
                        _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    _apiResponse.Result = "Something went wrong.";
                    _apiResponse.IsSuccess = false;
                    _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
                return Ok(_apiResponse);
            }
            catch(Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_apiResponse);
        }

        
        [HttpPost("Login")]
        public async Task<ActionResult<APIResponse>> Login([FromBody]LoginRequestDto loginRequestDto)
        {
            try
            {
                var identityUser = await _userManager.FindByEmailAsync(loginRequestDto.UserName);
                if(identityUser != null)
                {
                    var checkPwdResult = await _userManager.CheckPasswordAsync(identityUser, loginRequestDto.Password);
                    if(checkPwdResult)
                    {
                        var roles = await _userManager.GetRolesAsync(identityUser);
                        if(roles != null)
                        {
                            //Create Jwt token
                            var jwtToken = _tokenRepository.CreateJwtToken(identityUser, roles.ToList());
                            _loginResponseDto.JwtToken = jwtToken;
                            _loginResponseDto.User.Id = identityUser.Id;
                            _loginResponseDto.User.Name = identityUser.Email;
                            _loginResponseDto.User.UserName = identityUser.Email;
                            _loginResponseDto.User.Password = loginRequestDto.Password;
                            _apiResponse.Result = _loginResponseDto;
                            _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                        }
                        else
                        {
                            _apiResponse.Result = "Something went wrong.";
                            _apiResponse.ErrorMessages = new List<string>() { "Something went wrong." };
                            _apiResponse.IsSuccess = false;
                            _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        }
                    }
                    else
                    {
                        _apiResponse.Result = "Username or Password is not correct!!.";
                        _apiResponse.ErrorMessages = new List<string>() { "Username or Password is not correct!!." };
                        _apiResponse.IsSuccess = false;
                        _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    _apiResponse.Result = "Username does not exist.";
                    _apiResponse.ErrorMessages = new List<string>() { "Username does not exist." };
                    _apiResponse.IsSuccess = false;
                    _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
                return Ok(_apiResponse);
                 
            }
            catch(Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_apiResponse);
        }

    }
}

