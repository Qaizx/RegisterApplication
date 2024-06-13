using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Information
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CitizenId { get; set; } = string.Empty;

        public string PhoneNumber {  get; set; } = string.Empty;

        public List<string> Ability { get; set; } = [];

    }
}
