using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;
public class Users {

        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public byte[] salt { get; set; }

        public Information Information { get; set; }
 }

