using Microsoft.EntityFrameworkCore;
using WebApplication1.Admin.Dtos;
using WebApplication1.Authentication.Dtos;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.Interface;
using WebApplication1.User.Dtos;

namespace WebApplication1.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<IQueryable<Users>> FindUserByEmail(string email) 
        {
            return  _context.Users.Where(x => x.Email == email);
        }

        public async Task<Users> CreateUser(Users users, Information information)
        {
            await _context.Users.AddAsync(users);
            await _context.Information.AddAsync(information);
            await _context.SaveChangesAsync();
            return users;
        }

        public async Task<List<Users>> FindAllUser()
        {
            return await _context.Users.Include(i => i.Information).ToListAsync();
        }

        public async Task<IQueryable<Users>> SearchUser(string search)
        {
            
            return  _context.Users.Where(user => (user.Email == search) || (user.Information.FirstName == search) || (user.Information.LastName == search)).Include(i => i.Information); 
        }

        public async Task<Users> FindById(int Id)
        {
            return _context.Users.Include(i => i.Information).FirstOrDefault(x => x.Id == Id); 
        }

        public async Task<Users> EditUserInformation(EditInformationFromAdmin editInformation, int Id)
        {
            Users userTest = new Users();
            Users? users = await FindById(Id);
            if (users is null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            users.Email = editInformation.Email;
            users.Information.Name = editInformation.Name;
            users.Information.FirstName = editInformation.FirstName;
            users.Information.LastName = editInformation.LastName;
            users.Information.CitizenId = editInformation.CitizenId;
            users.Information.Ability = editInformation.Ability;
            await _context.SaveChangesAsync();
            return users;
        }

        public async Task<String> DeleteUser(int Id)
        {
            Users? users = await FindById(Id);
            if (users is null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            _context.Information.Remove(users.Information);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return $"User Id: {Id} has been delete";
        }

        public async Task<Users> EditUserInformationByUser(EditInformation editInformation, int Id)
        {
            Users? users = await FindById(Id);
            if (users is null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            users.Email = editInformation.Email;
            if (users.Information is null)
            {
                throw new Exception("Information is null");
            }
            users.Information.Name = editInformation.Name;
            users.Information.FirstName = editInformation.FirstName;
            users.Information.LastName = editInformation.LastName;
            users.Information.CitizenId = editInformation.CitizenId;
            users.Information.Ability = editInformation.Ability;
            await _context.SaveChangesAsync();
            return users;
        }
    }
}
