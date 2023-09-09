using Dabernasho.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dabernasho.Api.Features.Leaderboard.GetScores;

public class LeaderboardController : LeaderboardControllerBase
{
    private readonly ILeaderboardService _leaderboardService;

    public LeaderboardController(ILeaderboardService leaderboardService)
    {
        _leaderboardService = leaderboardService;
    }


    [HttpGet]
    public async Task<IEnumerable<GetScoreDto>> GetTop([FromQuery] GetScoreInputDto getScoreInputDto)
    {
        return await _leaderboardService.GetScoresAsync(getScoreInputDto);
    }
}