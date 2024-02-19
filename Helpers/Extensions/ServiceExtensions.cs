using Proiect.Helpers.Jwt;
using Proiect.Helpers.Seeders;
using Proiect.Repositories.PlayerRepository;
using Proiect.Repositories.TeamRepository;
using Proiect.Repositories.UserRepository;
using Proiect.Services.PlayerService;
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

            services.AddTransient<IPlayerRepository, PlayerRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<ITeamService, TeamService>();

            services.AddTransient<IPlayerService, PlayerService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<UsersSeeder>();

            return services;
        }

        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            services.AddTransient<IJwt, Jwt.Jwt>();

            return services;
        }
    }
}
