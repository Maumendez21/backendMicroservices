using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Service.Api.Auth.Core.JWTLogic
{
    public class UserSession : IUSerSession
    {

        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
        }

        public IHttpContextAccessor _HttpContextAccessor { get; }

        public string GetUserCurrent()
        {
            var userName = _HttpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault( x => x.Type == "username")?.Value;
            return userName;
        }
    }
}
