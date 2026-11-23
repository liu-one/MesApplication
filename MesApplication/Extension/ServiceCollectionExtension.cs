using MES.Application.InterFaces.Identity;
using MES.Application.Services.Identity;
using System.Reflection.Metadata.Ecma335;

namespace MesApplication.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();





            return services;
        }
        
            
    }
}
