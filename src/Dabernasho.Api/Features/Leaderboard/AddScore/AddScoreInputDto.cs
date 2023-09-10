using System.ComponentModel.DataAnnotations;

namespace Dabernasho.Api.Features.Leaderboard.AddScore;

public record AddScoreInputDto([Required] string Stat, [Required] double? Score, [Required] string Username);