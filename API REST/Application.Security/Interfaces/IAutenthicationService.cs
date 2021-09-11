using Application.Security.Core;
using System.Threading.Tasks;

namespace Application.Security.Interfaces
{
    public interface IAutenthicationService
    {
        Task<UserApp> Login(string username, string password);
    }
}