using Project.Core.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddApiConfiguration(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.Run();