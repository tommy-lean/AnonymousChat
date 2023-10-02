using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using TestProject.Context;

namespace TestProject.Infrastructure.IoC;

internal static class EntityFrameworkExtensions
{
    public static IServiceCollection AddDefaultEfCore(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddDbContextFactory<AppDbContext>((provider, builder) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();

                var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                                      throw new InvalidOperationException("Строка подключения к БД не настроена.");
                
                builder.UseNpgsql(connectionString, optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            });
        services.AddScoped<IAppDbContext, AppDbContext>();
        return services;
    }
}