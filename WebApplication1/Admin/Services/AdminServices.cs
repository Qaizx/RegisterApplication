using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplication1.Admin.Dtos;
using WebApplication1.Admin.Services.Interface;
using WebApplication1.Models;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Admin.Services
{
    public class AdminServices: IAdminServices
    {
        //private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly IInformationRepository _informationRepository;

        public AdminServices(IUserRepository userRepository, IInformationRepository informationRepository)
        {
            _userRepository = userRepository;
            _informationRepository = informationRepository;
        }

        public async Task<List<UserInformation>> GetAllInformation()
        {
            List<UserInformation> userInformationList = new List<UserInformation>();
            List<Users> users = await _userRepository.FindAllUser();

            foreach (Users user in users)
            {
                userInformationList.Add(convertUser(user));
            }

            return userInformationList;
        }

        public async Task<UserInformation> SearchUser(string search)
        {
            Users? user = (await _userRepository.SearchUser(search)).FirstOrDefault();
            return user is null ? throw new Exception("User not found") : convertUser(user);
        }

        public async Task<EditResponse> EditUser(EditInformationFromAdmin editInformation, int Id)
        {
            Users? users = await _userRepository.EditUserInformation(editInformation, Id);
            EditResponse response = new EditResponse();
            response.userInformation = convertUser(users);
            response.response = "User has been update";
            return response;
        }

        public async Task<string> DeleteUser(int Id)
        {
            return await _userRepository.DeleteUser(Id);
        }

        private UserInformation convertUser(Users users)
        {
            UserInformation userInformation = new UserInformation();
            //Should manage by mapper
            userInformation.Id = users.Id;
            userInformation.Email = users.Email;
            if (users.Information is not null)
            {
                userInformation.Name = users.Information.Name;
                userInformation.FirstName = users.Information.FirstName;
                userInformation.LastName = users.Information.LastName;
                userInformation.CitizenId = users.Information.CitizenId;
                userInformation.Ability = users.Information.Ability;
            }
            return userInformation;
        }
    }
}
