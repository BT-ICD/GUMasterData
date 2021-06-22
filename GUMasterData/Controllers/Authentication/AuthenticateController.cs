using GUMasterData.API.AuthData;
using GUMasterData.API.CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GUMasterData.API.Controllers.Authentication
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IAuthenticate authenticate;
        private ILogger<AuthenticateController> logger;
        public AuthenticateController(ILogger<AuthenticateController> logger, IAuthenticate authenticate)
        {
            this.logger = logger;
            this.authenticate = authenticate;
        }
        /// <summary>
        /// To authenticate user. Authenticated user can access token
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginModel login)
        {
            logger.LogInformation($"Login requested: {login.UserName}");
            string iPAddress = Utility.GetIPAddress(Request);
            string userAgent = Utility.GetUserAgent(Request);

            var result = await authenticate.AuthenticateUser(login, userAgent, iPAddress);
            if (result == null)
            {
                logger.LogInformation($"Invalid UserName or Password for User {login.UserName}");
                return Unauthorized();
            }
            else
            {
                logger.LogInformation($"Token for login {login.UserName} is generated {result.ToString()}");
                return Ok(result);
            }
        }
       
    }
}
