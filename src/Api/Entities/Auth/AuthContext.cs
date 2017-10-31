using Api.Entities.Default;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.Entities.Auth
{
    public class AuthContext : DefaultContext
    {
        public AuthContext(IConfiguration config) : base(config)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var defaultConnection = Configuration.GetConnectionString("AuthConnection");
            optionsBuilder.UseSqlServer(defaultConnection, b => b.MigrationsAssembly("Api"));
        }

        public DbSet<User> Users { get; set; }
    }
}
