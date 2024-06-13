using WebApplication1.Admin.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Admin.Services.Interface
{
    public interface IAdminServices
    {
        Task<List<UserInformation>> GetAllInformation();

        Task<UserInformation> SearchUser(string search);
        Task<EditResponse> EditUser(EditInformationFromAdmin editInformation, int Id);
        Task<string> DeleteUser(int Id);
    }
}
