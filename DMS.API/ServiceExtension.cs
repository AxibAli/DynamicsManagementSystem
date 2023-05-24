using DMS.BL.Services;

namespace DMS.API
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentRepo, StudentRepo>();
        }
    }
}
