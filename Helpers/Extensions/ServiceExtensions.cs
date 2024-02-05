using Proiect.Helpers.Seeders;
using Proiect.Repositories.TeamRepository;
using Proiect.Repositories.UserRepository;
using Proiect.Services.TeamService;
using Proiect.Services.UserService;

namespace Proiect.Helpers.Extensions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ITeamRepository, TeamRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<ITeamService, TeamService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<UsersSeeder>();

            return services;
        }
    }
}
