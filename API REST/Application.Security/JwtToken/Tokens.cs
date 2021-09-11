using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Security.JwtToken
{
    public class Tokens
    {
        public static async Task<JwtResponse> GenerateJwt(
                ClaimsIdentity identity,
                IJwtFactory jwtFactory,
                string userName,
                JwtIssuerOptions jwtOptions,
                JsonSerializerSettings serializerSettings)
        {
            var response = new JwtResponse
            {
                Id = identity.Claims.Single(c => c.Type == "id").Value,
                AuthToken = await jwtFactory.GenerateEncodedToken(userName, identity),
                ExpireIn = (int)jwtOptions.ValidFor.Days*1300
            };

            return response;
        }
    }
}