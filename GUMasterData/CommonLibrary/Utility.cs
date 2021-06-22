using Microsoft.AspNetCore.Http;

namespace GUMasterData.API.CommonLibrary
{
    public class Utility
    {
        public static string GetIPAddress(HttpRequest httpRequest)
        {
            return httpRequest.HttpContext.Connection.RemoteIpAddress.ToString();
        }
        public static string GetUserAgent(HttpRequest httpRequest)
        {
            return httpRequest.Headers["User-Agent"].ToString();
        }
    }
}
