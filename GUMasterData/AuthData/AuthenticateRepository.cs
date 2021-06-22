using GUMasterData.API.AppRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUMasterData.API.AuthData
{
    public class AuthenticateRepository : IAuthenticate
    {
        private UserManager<ApplicationUser> userManager;
        private TokenGenerator tokenGenerator;
        private IAppUser appUser;
        private SignInManager<ApplicationUser> signInManager;
        public AuthenticateRepository(UserManager<ApplicationUser> userManager, TokenGenerator tokenGenerator, IAppUser appUser, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.userManager.PasswordHasher = new CustomPasswordHasher();
            this.tokenGenerator = tokenGenerator;
            this.appUser = appUser;
            this.signInManager = signInManager;
        }
        public async Task<TokenModel> AuthenticateUser(LoginModel login, string userAgent, string iPAddress)
        {
            var user = await userManager.FindByNameAsync(login.UserName);

            if (user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {
                //Get roles for the user
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Count == 1)
                {
                    //var user = await userManager.FindByNameAsync(login.UserName);
                    var result = tokenGenerator.GenerateToken(user.UserName, roles[0]);
                    return result;
                }
                return null;
            }
            return null;
        }
    }
}
