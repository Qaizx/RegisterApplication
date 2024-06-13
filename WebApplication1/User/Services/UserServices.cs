using WebApplication1.Admin.Dtos;
using WebApplication1.Models;
using WebApplication1.Repository.Interface;
using WebApplication1.User.Dtos;
using WebApplication1.User.Services.Interface;

namespace WebApplication1.User.Services
{
    public class UserServices: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IInformationRepository _informationRepository;
        public UserServices(IUserRepository userRepository, IInformationRepository informationRepository) 
        {
            _userRepository = userRepository;
            _informationRepository = informationRepository;
        }

        public async Task<GetInformation> GetInformation(int id) 
        {
            Users users = await _userRepository.FindById(id);
            GetInformation getInformation = new GetInformation();
            getInformation.Email = users.Email;
            getInformation.information = users.Information;
            return getInformation;
        } 

        public async Task<EditResponseUser> EditInformation(EditInformation editInformation, int Id)
        {
            Users? users = await _userRepository.EditUserInformationByUser(editInformation, Id);
            EditResponseUser response = new EditResponseUser();
            GetInformation getInformation = new GetInformation()
            {
                Email = users.Email,
                information = users.Information
            };
            response.getInformation = getInformation;
            response.response = "User has been update";
            return response;
        }
    }
}
