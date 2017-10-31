using Api.Entities.Default;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.Entities.QA
{
    public class QAContext : DefaultContext
    {
        protected QAContext(IConfiguration config) : base(config)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var defaultConnection = Configuration.GetConnectionString("QAConnection");
            optionsBuilder.UseSqlServer(defaultConnection, b => b.MigrationsAssembly("Api"));
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
