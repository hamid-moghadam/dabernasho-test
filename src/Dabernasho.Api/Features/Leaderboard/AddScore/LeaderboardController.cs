using Dabernasho.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dabernasho.Api.Features.Leaderboard.AddScore;

public class LeaderboardController : LeaderboardControllerBase
{
    private readonly ILeaderboardService _leaderboardService;

    public LeaderboardController(ILeaderboardService leaderboardService)
    {
        _leaderboardService = leaderboardService;
    }

    [HttpPost]
    public async Task<IResult> SetScore([FromQuery] AddScoreInputDto addScoreInputDto)
    {
        await _leaderboardService.SetScoreAsync(addScoreInputDto);
        return Results.Ok();
    }
}