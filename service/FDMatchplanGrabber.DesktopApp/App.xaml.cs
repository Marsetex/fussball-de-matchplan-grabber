using FDMatchplanGrabber.Business.Services;
using FDMatchplanGrabber.Business.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace FDMatchplanGrabber.DesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public App()
        {
            AppHost = Host
                .CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddTransient<IMatchplanGrabberApplicationService, MatchplanGrabberApplicationService>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs args)
        {
            await AppHost.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(args);
        }

        protected override async void OnExit(ExitEventArgs args)
        {
            await AppHost.StopAsync();

            base.OnExit(args);
        }
    }
}
