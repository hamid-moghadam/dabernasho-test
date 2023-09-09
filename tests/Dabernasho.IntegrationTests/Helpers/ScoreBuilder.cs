using Dabernasho.Api.Features.Leaderboard.AddScore;

namespace Dabernasho.IntegrationTests.Helpers;

public static class ScoreBuilder
{
    public static IEnumerable<AddScoreInputDto> GenerateRandomScores(string stat)
    {
        var random = new Random();
        return Enumerable.Range(0, 100).Select(x =>
            new AddScoreInputDto(stat, random.Next(0, 1000), $"user-{random.Next(3000, 50000)}"));
    }
}