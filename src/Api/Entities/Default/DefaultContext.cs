using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Api.Entities.Default
{
    public class DefaultContext : DbContext
    {
        public Guid TenantId { get; set; }
        public IConfiguration Configuration { get; }

        public DefaultContext(IConfiguration config)
        {
            Configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var defaultConnection = Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(defaultConnection, b => b.MigrationsAssembly("Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DbConfig.RemovePluralizingTableNameConvention(modelBuilder);
            DbConfig.Tenant(modelBuilder, TenantId);
        }

        protected static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
        {
            var sqlExt = options.Extensions.FirstOrDefault(e => e is SqlServerOptionsExtension);

            if (sqlExt == null)
                throw (new Exception("Failed to retrieve SQL connection string for base Context"));

            return new DbContextOptionsBuilder<T>()
                        .UseSqlServer(((SqlServerOptionsExtension)sqlExt).ConnectionString)
                        .Options;
        }
    }

    public static class DbConfig
    {
        public static void Tenant(ModelBuilder modelBuilder, Guid tenantId)
        {
            modelBuilder.Entity<DefaultEntity>()
                .HasQueryFilter(p => p.TenantId == tenantId);
        }

        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
        }
    }
}
