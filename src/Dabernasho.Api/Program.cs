using Dabernasho.Api.Extensions;
using Dabernasho.Api.Extensions.Services;
using Dabernasho.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//scope or signleton?
builder.Services.AddScoped<ILeaderboardService, RedisLeaderboardService>();

builder.Services
    .AddCustomConfigurations(builder.Configuration)
    .AddRedis(builder.Configuration)
    .AddQuartz(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.ConfigureExceptionHandler();
app.MapControllers();

app.Run();


public partial class Program
{
}