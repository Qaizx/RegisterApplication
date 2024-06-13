using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Admin.Dtos;
using WebApplication1.Admin.Services.Interface;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.User.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Admin.Controllers
{
    [Route("api/admin")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;
        public AdminController(DataContext context, IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        [HttpGet("v1/AllInformation")]
        public async Task<ActionResult> GetAllInformation()
        {
            return Ok(await _adminServices.GetAllInformation());
        }

        [HttpGet("v1/SearchUser")]
        public async Task<ActionResult> SearchUser(string search)
        {
            return Ok(await _adminServices.SearchUser(search));
        }

        [HttpPut("v1/user/{Id}/edit")]
        public async Task<ActionResult> EditUserInformation([FromBody] EditInformationFromAdmin editInformation, int Id)
        {
            return Ok(await _adminServices.EditUser(editInformation, Id));
        }

        [HttpDelete("v1/user/delete")]
        public async Task<ActionResult> DeleteUser(DeleteUser delete)
        {
            return Ok(await _adminServices.DeleteUser(delete.Id));
        }
    }
}
