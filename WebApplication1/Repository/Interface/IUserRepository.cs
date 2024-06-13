using WebApplication1.Admin.Dtos;
using WebApplication1.Models;
using WebApplication1.User.Dtos;

namespace WebApplication1.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IQueryable<Users>> FindUserByEmail(string email);

        Task<Users> CreateUser(Users users, Information information);

        Task<List<Users>> FindAllUser();

        Task<IQueryable<Users>> SearchUser(string search);

        Task<Users> FindById(int Id);
        Task<Users> EditUserInformation(EditInformationFromAdmin editInformation, int Id);
        Task<string> DeleteUser(int Id);

        Task<Users> EditUserInformationByUser(EditInformation editInformation, int Id);
    }
}
