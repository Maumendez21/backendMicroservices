using Microsoft.AspNetCore.Identity;

namespace Service.Api.Auth.Core.Entities
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
    }
}
