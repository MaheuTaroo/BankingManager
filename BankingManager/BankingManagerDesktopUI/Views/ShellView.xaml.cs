using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace BankingManagerDesktopUI.Views
{
    public partial class ShellView
    {
        public ShellView() => InitializeComponent();

        public static readonly DependencyProperty TryCloseCommandProperty = DependencyProperty.Register(
            nameof(TryCloseCommand), 
            typeof(ICommand), 
            typeof(ShellView), 
            new PropertyMetadata(null));

        public ICommand TryCloseCommand
        {
            get => (ICommand) GetValue(TryCloseCommandProperty);
            set => SetValue(TryCloseCommandProperty, value);
        }

        private void ShellView_OnClosing(object sender, CancelEventArgs e)
        {
            if (TryCloseCommand is null) return;

            e.Cancel = true;
            TryCloseCommand?.Execute(null);
        }
    }
}
