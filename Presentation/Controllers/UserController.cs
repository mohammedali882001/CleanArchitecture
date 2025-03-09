using Application.DTOs.Auth;
using Application.GeneralResponses;
using Application.Interfaces.Services;
using Infrastructure.Auth;
using Infrastructure.Implementations.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAuthentication userAuthentication;

        public UserController(IUserAuthentication _user)
        {
           this.userAuthentication = _user;
        }

        [HttpPost("Register")]
        public ActionResult<GeneralResponse<string>> Register(UserRegisterDto user)
        {
            GeneralResponse<string> response=userAuthentication.Register(user);
            if (response.IsSuccess==true)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("Login")]
        public ActionResult<GeneralResponse<string>> Login(UserForLoginDto user)
        {

            GeneralResponse<string> response = userAuthentication.Login(user);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
