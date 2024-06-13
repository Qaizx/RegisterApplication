

using WebApplication1.Models;

namespace WebApplication1.Repository.Interface
{
    public interface IInformationRepository
    {
        Task<Information> FindInformationById(int Id);
        Task<Information> CreateInformation(Information information);
    }
}
