namespace Dabernasho.Api.Features.Leaderboard.ResetScores;

public class ResetScoreJobOptions
{
    public const string Key = "Configs:ResetScoreJob";

    public string Cron { get; set; }
}