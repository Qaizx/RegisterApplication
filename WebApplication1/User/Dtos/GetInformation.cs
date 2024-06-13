using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.User.Dtos
{
    public class GetInformation
    {
        [EmailAddress]
        public string Email { get; set; }
        public Information information { get; set; }
    }
}
