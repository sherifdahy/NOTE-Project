using Microsoft.EntityFrameworkCore;
using NOTE.Solutions.DAL.Data;
using System.Runtime.CompilerServices;

namespace NOTE.Solutions.API.ApplicationConfiguration;

public static class DInjection
{
    public static IServiceCollection DI (this IServiceCollection services,IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSwaggerConfig();
        services.AddDbConfig(configuration);

        return services;
    }

    private static IServiceCollection AddDbConfig(this IServiceCollection services,IConfiguration configuration)
    {
        string? connectionString = configuration?.GetConnectionString("default");

        if (connectionString is null)
            throw new Exception("Invalid Connection String");

        services.AddDbContext<ApplicationDbContext>(x =>
        {
            x.UseSqlServer(connectionString);
        });
        return services;
    }
    private static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
