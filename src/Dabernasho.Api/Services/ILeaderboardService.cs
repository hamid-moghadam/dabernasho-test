using Dabernasho.Api.Features.Leaderboard.AddScore;
using Dabernasho.Api.Features.Leaderboard.GetScores;

namespace Dabernasho.Api.Services;

public interface ILeaderboardService
{
    Task SetScoreAsync(AddScoreInputDto input);
    Task<IEnumerable<GetScoreDto>> GetScoresAsync(GetScoreInputDto input, int count = 20);
    Task ResetScoresAsync();
}