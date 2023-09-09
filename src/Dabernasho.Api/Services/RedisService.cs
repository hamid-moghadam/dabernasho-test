using Dabernasho.Api.Features.Leaderboard.AddScore;
using Dabernasho.Api.Features.Leaderboard.GetScores;
using StackExchange.Redis;

namespace Dabernasho.Api.Services;

public class RedisLeaderboardService : ILeaderboardService
{
    private readonly IDatabase _redisClient;
    private const string LeaderboardsKey = "leaderboards";

    public RedisLeaderboardService(IConnectionMultiplexer redisClient)
    {
        _redisClient = redisClient.GetDatabase();
    }


    public async Task SetScoreAsync(AddScoreInputDto input)
    {
        await _redisClient.SortedSetAddAsync(input.Stat, input.Username, input.Score);
        await _redisClient.SetAddAsync(LeaderboardsKey, input.Stat);
    }

    public async Task<IEnumerable<GetScoreDto>> GetScoresAsync(GetScoreInputDto input, int count = 20)
    {
        var results =
            await _redisClient.SortedSetRangeByRankWithScoresAsync(input.Stat, 0, input.Count - 1, Order.Descending);

        return results.Select(x => new GetScoreDto(x.Element.ToString(), x.Score)).ToArray();
    }

    public async Task ResetScoresAsync()
    {
        //todo: should check concurrency issue
        var members = await _redisClient.SetMembersAsync(LeaderboardsKey);
        await _redisClient.KeyDeleteAsync(members.Select(x => (RedisKey)x.ToString()).ToArray());
        await _redisClient.SetRemoveAsync(LeaderboardsKey, members);
    }
}