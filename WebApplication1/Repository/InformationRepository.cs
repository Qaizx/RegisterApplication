using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Repository
{
    public class InformationRepository: IInformationRepository
    {
        private readonly DataContext _context;

        public InformationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Information> FindInformationById(int Id)
        {
            return await _context.Information.FindAsync(Id);
        }
        public async Task<Information> CreateInformation(Information information)
        {
            _context.Information.Add(information);
            _context.SaveChanges();
            return information;
        }
    }
}
