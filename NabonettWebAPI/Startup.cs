using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Core;
using Core.DataInterfaces;
using Data;
using Data.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Data.Contacts;

namespace NabonettWebAPI
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
            ConfigureDatabaseProvider(services);
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen();


            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IUserRepository, UsersRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
        }

        protected virtual void ConfigureDatabaseProvider(IServiceCollection services)
        {
            services.AddDbContext<NabonettContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:NabonettDB"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            { endpoints.MapControllers(); });
        }
    }
}