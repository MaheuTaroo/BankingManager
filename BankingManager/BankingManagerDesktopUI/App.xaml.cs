using System;
using System.Windows;
using BankingManagerDataLib.Services;
using BankingManagerDesktopUI.Services;
using BankingManagerDesktopUI.ViewModels;
using BankingManagerDesktopUI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace BankingManagerDesktopUI
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = GetServiceProvider();

            var window = new ShellView
            {
                DataContext = services.GetRequiredService<ShellViewModel>()
            };
            window.Show();

            base.OnStartup(e);
        }

        private static IServiceProvider GetServiceProvider() =>
            new ServiceCollection()
                .AddSingleton<Navigator>()
                .AddSingleton<ShellViewModel>()
#if DEBUG
                .AddSingleton<SampleDataService>()
#endif
                .AddSingleton<IDialogService, DialogService>()
                .AddSingleton<HomeViewModel>()
                    .BuildServiceProvider();
    }
}
