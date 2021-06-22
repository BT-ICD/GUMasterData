using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUMasterData.API.AuthData
{
    public interface IAuthenticate
    {
        Task<TokenModel> AuthenticateUser(LoginModel login, string userAgent, string iPAddress);
        //DataUpdateResponseDTO SignOut(string userName, Guid loginHistoryId);

    }
}
