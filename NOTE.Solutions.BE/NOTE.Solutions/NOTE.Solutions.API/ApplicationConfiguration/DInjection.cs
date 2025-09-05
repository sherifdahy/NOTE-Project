using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "NOTE.Solutions API",
                Version = "v1",
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
        });
        return services;
    }

}
