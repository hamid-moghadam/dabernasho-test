namespace Dabernasho.Api.Features.Leaderboard.GetScores;

public record GetScoreInputDto(string Stat, int Count = 20);