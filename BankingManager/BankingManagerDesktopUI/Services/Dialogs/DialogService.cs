using System;
using System.Collections.Generic;
using System.Text;
using BankingManagerDesktopUI.ViewModels;
using BankingManagerDesktopUI.Views;

namespace BankingManagerDesktopUI.Services
{
    public class DialogService : IDialogService
    {
        public T OpenDialog<T>(DialogViewModelBase<T> viewModel)
        {
            IDialogWindow window = new DialogView { DataContext = viewModel };
            window.ShowDialog();
            return viewModel.DialogResult;
        }
    }
}
