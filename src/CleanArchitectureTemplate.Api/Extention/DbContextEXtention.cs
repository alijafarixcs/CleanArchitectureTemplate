using CleanArchitectureTemplate.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArchitectureTemplate.API.Extensions
{
    public static class DbContextExtension
    {
        public static void EnsureDatabaseCreated(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbc = scope.ServiceProvider.GetService<AppDbContext>();
            if (dbc != null)
            {
                dbc.Database.EnsureCreated();
                dbc.Database.CloseConnection();
            }
        }
    }
}
