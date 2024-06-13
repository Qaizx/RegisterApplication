using WebApplication1.Models;
using WebApplication1.User.Dtos;

namespace WebApplication1.User.Services.Interface
{
    public interface IUserService
    {
        Task<GetInformation> GetInformation(int id);

        Task<EditResponseUser> EditInformation(EditInformation editInformation, int Id);
    }
}
