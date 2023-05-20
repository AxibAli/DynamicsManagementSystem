using DMS.BL.Services;
using DMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DMS.API
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddDbContextPool<ApplicationDBContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("cs")));
            
            AddScopes(services);

            services.AddSwaggerGen();
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: "CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
        }

        private static void AddScopes(IServiceCollection services)
        {
            services.AddScoped<IStudentRepo, StudentRepo>();
        }
    }
}
