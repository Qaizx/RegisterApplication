using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Authentication.Dtos;
using WebApplication1.Authentication.Services;
using WebApplication1.Authentication.Services.Interface;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Authentication.Controllers
{
    [Route("api/authen")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenService _authenServices;

        public AuthenController(IAuthenService authenServices)
        {;
            _authenServices = authenServices;
        }

        [HttpPost("v1/login")]
        public async Task<ActionResult> LoginUser([FromBody] Login login)
        {
            return Ok(await _authenServices.Login(login));
        }

        [HttpPost("v1/register")]
        public async Task<ActionResult> RegisterUser([FromBody] Register register)
        {
            return Ok(await _authenServices.Register(register));
        }

      
    }
}
