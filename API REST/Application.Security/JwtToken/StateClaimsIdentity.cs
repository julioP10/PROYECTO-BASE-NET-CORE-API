using System.Security.Claims;

namespace Application.Security.JwtToken
{
    public class StateClaimsIdentity
    {
        public int State { get; set; }
        public ClaimsIdentity ClaimsIdentity { get; set; }

        public StateClaimsIdentity(int state)
        {
            State = state;
        }
    }
}