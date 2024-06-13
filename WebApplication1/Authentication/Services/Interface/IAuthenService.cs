using WebApplication1.Authentication.Dtos;

namespace WebApplication1.Authentication.Services.Interface
{
    public interface IAuthenService
    {
        Task<LoginResponse> Login(Login login);

        Task<ResultReturn> Register(Register register);
    }
}
