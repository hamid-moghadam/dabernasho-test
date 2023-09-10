using System.ComponentModel.DataAnnotations;

namespace Dabernasho.Api.Features.Leaderboard.GetScores;

public record GetScoreInputDto([Required] string Stat, int Count = 20);