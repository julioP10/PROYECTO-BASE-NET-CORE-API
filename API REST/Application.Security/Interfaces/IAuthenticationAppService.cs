using Application.Security.JwtToken;
using System.Threading.Tasks;

namespace Application.Security.Interfaces
{
    public interface IAuthenticationAppService
    {
        Task<JwtResponse> LoginAsync(string username, string password);
    }
}
