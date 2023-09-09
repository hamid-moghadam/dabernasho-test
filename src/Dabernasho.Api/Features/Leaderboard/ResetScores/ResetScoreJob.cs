using Dabernasho.Api.Services;
using Quartz;

namespace Dabernasho.Api.Features.Leaderboard.ResetScores;

public class ResetScoreJob : IJob
{
    public const string Key = "ResetJob";
    public const string Name = "ResetScoreJob-trigger";

    private readonly ILeaderboardService _leaderboardService;

    public ResetScoreJob(ILeaderboardService leaderboardService)
    {
        _leaderboardService = leaderboardService;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await _leaderboardService.ResetScoresAsync();
    }
}