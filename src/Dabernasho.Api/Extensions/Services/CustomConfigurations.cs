using Dabernasho.Api.Features.Leaderboard.ResetScores;

namespace Dabernasho.Api.Extensions.Services;

public static class CustomConfigurations
{
    public static IServiceCollection AddCustomConfigurations(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services.Configure<ResetScoreJobOptions>(
            configuration.GetSection(ResetScoreJobOptions.Key));
    }
}