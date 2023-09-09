using Microsoft.AspNetCore.Mvc.Testing;

namespace Dabernasho.IntegrationTests.Helpers;

public class BaseTests : IDisposable, IAsyncDisposable
{
    protected CustomWebApplicationFactory<Program> _factory;
    protected HttpClient Client { get; private set; }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _factory = new CustomWebApplicationFactory<Program>();
        Client = _factory
            .CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
    }

    public void Dispose()
    {
        _factory.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _factory.DisposeAsync();
    }
}