using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using vebtech_test.DAL.Repositories.IRepositories;
using vebtech_test.DAL.Repositories;
using vebtech_test.DAL.DateDbContext;
using Microsoft.EntityFrameworkCore;

namespace vebtech_test.DAL
{
    public static class DependencyInjection
    {
        public static void RegisterDAL(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<VebtechDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection"));
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
