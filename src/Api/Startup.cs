using Api.Entities.Default;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigDatabaseConnection(services);

            services.AddMvc();
            services.AddTransient<DefaultContext>();
        }

        private void ConfigDatabaseConnection(IServiceCollection services)
        {
            //database
            services.AddSingleton(Configuration);
            services.AddDbContext<DefaultContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Create database schema
            //this.Migrate(app);
            app.UseMvc();
        }

        private void Migrate(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var qaContext = serviceScope.ServiceProvider.GetRequiredService<DefaultContext>();
                qaContext.Database.Migrate();
            }
        }
    }
}
