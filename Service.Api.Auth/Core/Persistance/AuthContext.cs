using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Service.Api.Auth.Core.Entities;

namespace Service.Api.Auth.Core.Persistance
{
    public class AuthContext : IdentityDbContext<User>
    {
        public AuthContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        //public DbSet<MyEntity> MyEntity { get; set;}
    }
}
