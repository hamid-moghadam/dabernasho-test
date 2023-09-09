using System.Collections;
using System.Net;
using System.Net.Http.Json;
using Dabernasho.Api.Features.Leaderboard.AddScore;
using Dabernasho.Api.Features.Leaderboard.GetScores;
using Dabernasho.IntegrationTests.Helpers;
using FluentAssertions;

namespace Dabernasho.IntegrationTests.ControllerTests.Leaderboards;

public class LeaderboardTests : BaseTests
{
    [TestCaseSource(typeof(SetScoreDataClass))]
    public async Task AddScore_WithNormalValues_ReturnsOk(AddScoreInputDto inputDto)
    {
        var result =
            await Client.PostAsync($"api/v1/Leaderboard/SetScore?{ObjectHelpers.ToQueryString(inputDto)}", null);

        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task GetScore_WithoutData_ReturnsOk()
    {
        var result =
            await Client.GetAsync($"api/v1/Leaderboard/GetTop?stat=x");

        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task GetScore_WithNormalRandomValues_ReturnsOk()
    {
        var scores = ScoreBuilder.GenerateRandomScores("test-stat");
        foreach (var addScoreInputDto in scores)
        {
            await Client.PostAsync($"api/v1/Leaderboard/SetScore?{ObjectHelpers.ToQueryString(addScoreInputDto)}",
                null);
        }

        var result =
            await Client.GetFromJsonAsync<GetScoreDto[]>($"api/v1/Leaderboard/GetTop?stat=test-stat");

        result.Should().NotBeEmpty();
        result.Length.Should().Be(20);
        result.First().Score.Should().BeGreaterThanOrEqualTo(result.Last().Score);
    }
}

public class SetScoreDataClass : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new AddScoreInputDto("test1", 3, "hamid");
        yield return new AddScoreInputDto("test1", 52, "ali");
        yield return new AddScoreInputDto("test1", 13, "hossein");
    }
}

public class GetTopDataClass : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new AddScoreInputDto("test2", 30, "nader");
        yield return new AddScoreInputDto("test2", 48, "baran");
        yield return new AddScoreInputDto("test2", 54, "bahar");
    }
}