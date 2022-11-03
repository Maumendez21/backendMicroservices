using Microsoft.AspNetCore.Identity;
using Service.Api.Auth.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Api.Auth.Core.Persistance
{
    public class AuthData
    {
        public static async Task UserInsert(AuthContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    Name = "Mau",
                    Lastname = "Mendez",
                    Adress = "Estrella 37 Santa Maria Xonacatepec",
                    UserName = "Kingmau",
                    Email = "mau@gmail.com"
                };


                await userManager.CreateAsync(user, "Admin123*");
            }
        }
    }
}
