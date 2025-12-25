using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NOTE.Solutions.WPF.Configurations;
using NOTE.Solutions.WPF.Views.Windows;
using System;
using System.Windows;

namespace NOTE.Solutions.WPF
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = default!;
        public static IConfiguration Configuration { get; private set; } = default!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            Configuration = services.AddAppConfiguration();
            services.AddApplicationServices(Configuration);

            ServiceProvider = services.BuildServiceProvider();

            ServiceProvider
                .GetRequiredService<LoginWindow>()
                .Show();
        }
    }
}
