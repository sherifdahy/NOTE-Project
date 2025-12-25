using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NOTE.Solutions.WPF.Handlers;
using NOTE.Solutions.WPF.Interfaces;
using NOTE.Solutions.WPF.Options;
using NOTE.Solutions.WPF.Services;
using NOTE.Solutions.WPF.ViewModels;
using NOTE.Solutions.WPF.Views;
using NOTE.Solutions.WPF.Views.UserControls;
using NOTE.Solutions.WPF.Views.Windows;
using Refit;
using System;

namespace NOTE.Solutions.WPF.Configurations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<NoteOptions>(
            configuration.GetSection(nameof(NoteOptions)));

        services.AddDistributedMemoryCache();

        services.AddRefitConfig(configuration);

        services.AddTransient<AuthHeaderHandler>();

        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<ICacheService, CacheService>();
        services.AddTransient<IProductService, ProductService>();

        services.AddTransient<ProductsViewModel>();
        services.AddTransient<LoginViewModel>();
        services.AddTransient<MainViewModel>();


        services.AddTransient<HomeControl>();
        services.AddTransient<AccountControl>();
        services.AddTransient<CustomersControl>();
        services.AddTransient<ProductsControl>();
        services.AddTransient<NewProductControl>();
        services.AddTransient<ReceiptsControl>();


        services.AddTransient<LoginWindow>();
        services.AddTransient<MainWindow>();

        return services;
    }



    private static void AddRefitConfig(this IServiceCollection services,IConfiguration configuration)
    {
        //services.AddRefitClient<IProductAPI>()
        //    .ConfigureHttpClient(c =>
        //    {
        //        c.BaseAddress = new Uri(configuration.GetValue<string>("NoteOptions:BaseUrl"));
        //    }).AddHttpMessageHandler<AuthHeaderHandler>();
    }
}
