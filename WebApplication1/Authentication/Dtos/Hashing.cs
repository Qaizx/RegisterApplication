namespace WebApplication1.Authentication.Dtos
{
    public class Hashing
    {
        public string HashPassword { get; set; }
        public byte[] Salt { get; set; }
    }
}
