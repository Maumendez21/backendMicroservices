using Service.Api.Auth.Core.Entities;

namespace Service.Api.Auth.Core.JWTLogic
{
    public interface IJWTGenerator
    {
        string GenerateToken(User user);
    }
}
