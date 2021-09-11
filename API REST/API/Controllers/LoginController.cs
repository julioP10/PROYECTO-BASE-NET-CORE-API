using Application.Dto;
using Application.Security.Interfaces;
using Application.Security.JwtToken;
using Infraestructure.Crosscutting;
using Infraestructure.Crosscutting.Logging;
using Infraestructure.Crosscutting.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationAppService _authenticationAppService;

        public LoginController(
            IAuthenticationAppService authenticationAppService)
        {
            _authenticationAppService = authenticationAppService;
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult<JsonResult<JwtResponse>>> Autenticar([FromBody] LoginUsuarioDto login)
        {
            if (login == null)
            {
                return BadRequest();
            }

            var jwtToken = await _authenticationAppService.LoginAsync(login.Username, login.Password);

            return new OkObjectResult(new JsonResult<JwtResponse>(jwtToken));
        }

        [HttpGet("Encrypt")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Encript([FromQuery] string value)
        {
            var result = Encrypters.Encrypt(value);
            return new OkObjectResult(new JsonResult<string>(result));
        }

        [HttpGet("Decrypt")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Decrypt([FromQuery] string value)
        {
            var result = Encrypters.Decrypt(value);
            return new OkObjectResult(new JsonResult<string>(result));
        }

        [HttpGet("EncryptV2")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult EncryptV2([FromQuery] string value)
        {
            var result = CryptoCustom.EncryptByAES(value);
            return new OkObjectResult(new JsonResult<string>(result));
        }

        [HttpGet("DecryptV2")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult DecryptV2([FromQuery] string value)
        {
            var result = CryptoCustom.DecryptByAES(value);
            return new OkObjectResult(new JsonResult<string>(result));
        }
    }
}
