using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RuleCheck.Application.Interfaces;
using RuleCheck.Infrastructure.Persistence;
using RuleCheck.Infrastructure.Services;

namespace RuleCheck.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RuleCheckDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IRuleService, RuleService>();

        return services;
    }

}
