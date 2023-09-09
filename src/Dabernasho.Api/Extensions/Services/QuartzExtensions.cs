using Dabernasho.Api.Features.Leaderboard.ResetScores;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.AspNetCore;

namespace Dabernasho.Api.Extensions.Services;

public static class QuartzExtensions
{
    public static IServiceCollection AddQuartz(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddQuartz(q =>
            {
                using var scope = services.BuildServiceProvider().CreateScope();
                var resetScoreOptions = scope.ServiceProvider.GetRequiredService<IOptions<ResetScoreJobOptions>>();
                
                var jobKey = new JobKey(ResetScoreJob.Key);
                q.AddJob<ResetScoreJob>(opts => opts.WithIdentity(jobKey));
                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity(ResetScoreJob.Name)
                    .WithCronSchedule(resetScoreOptions.Value.Cron)
                );
            })
            .AddQuartzServer(options => { options.WaitForJobsToComplete = true; });
    }
}