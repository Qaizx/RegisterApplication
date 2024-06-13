using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Admin.Dtos
{
    public class EditInformationFromAdmin
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CitizenId { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public List<string> Ability { get; set; } = [];
    }
}
