using BankingManagerDesktopUI.ViewModels;

namespace BankingManagerDesktopUI.Services
{
    public interface IDialogService
    {
        public T OpenDialog<T>(DialogViewModelBase<T> viewModel);
    }
}