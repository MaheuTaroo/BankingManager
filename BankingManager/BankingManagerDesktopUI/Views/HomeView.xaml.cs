using System.Windows;
using System.Windows.Input;

namespace BankingManagerDesktopUI.Views
{
    public partial class HomeView
    {
        public HomeView() => InitializeComponent();

        public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register(
            nameof(LoadAsyncCommand), 
            typeof(ICommand), 
            typeof(HomeView), 
            new PropertyMetadata(null));

        public ICommand LoadAsyncCommand
        {
            get => (ICommand) GetValue(PropertyTypeProperty);
            set => SetValue(PropertyTypeProperty, value);
        }

        private void HomeView_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadAsyncCommand?.Execute(null);
        }
    }
}
