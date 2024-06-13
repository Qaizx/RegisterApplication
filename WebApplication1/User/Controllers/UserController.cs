using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.User.Dtos;
using WebApplication1.User.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.User.Controllers
{
    [Route("api/user")]
    [ApiController]
    //[Authorize(Roles = "User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("v1/{Id}")]
        public async Task<ActionResult> GetInformation(int Id)
        {
            // Retrieve userId from the claims
            //string? userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _userService.GetInformation(Id));
        }

        [HttpPut("v1/edit/{Id}")]
        public async Task<ActionResult> EditInformation([FromBody] EditInformation editInformation, int Id)
        {
            return Ok(await _userService.EditInformation(editInformation, Id));
        }

    }
}
