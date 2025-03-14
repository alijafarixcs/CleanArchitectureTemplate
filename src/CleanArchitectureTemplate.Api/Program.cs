using CleanArchitectureTemplate.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureTemplate.Application;
using CleanArchitectureTemplate.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Load Configuration
var configuration = builder.Configuration;

// Add services to the container
builder.Services.AddApplicationServices()
                .AddInfrastructureServices(configuration);
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwaggerUi(options =>
        {
            options.DocumentPath = "openapi/v1.json";
            options.Path = "/swagger";
        });
    }
    app.EnsureDatabaseCreated();

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseHttpsRedirection();
    app.Run();
}




