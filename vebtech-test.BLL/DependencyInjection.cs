using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using vebtech_test.BLL.Services.IServices;
using vebtech_test.BLL.Services;
using vebtech_test.BLL.Utilites.AutoMapperProfiles;

namespace vebtech_test.BLL
{
    public static class DependencyInjection
    {
        public static void RegisterBLL(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles));
        }
    }
}
