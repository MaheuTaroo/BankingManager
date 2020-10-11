using System.Windows;
using BankingManagerDesktopUI.ViewModels;
using BankingManagerDesktopUI.Views;

namespace BankingManagerDesktopUI
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new ShellView
            {
                DataContext = new ShellViewModel()
            };
            window.Show();

            base.OnStartup(e);
        }
    }
}
