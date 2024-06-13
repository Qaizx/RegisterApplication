namespace WebApplication1.Authentication.Dtos
{
    public class LoginResponse
    {
        public string token {  get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }
}
