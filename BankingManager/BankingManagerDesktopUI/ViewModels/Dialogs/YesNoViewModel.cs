using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BankingManagerDesktopUI.Commands;
using BankingManagerDesktopUI.Services;

namespace BankingManagerDesktopUI.ViewModels
{
    public class YesNoViewModel : DialogViewModelBase<bool?>
    {
        public ICommand YesCommand { get; }
        public ICommand NoCommand { get; }

        public YesNoViewModel(string windowTitle, string message) : base(windowTitle, message)
        {
            YesCommand = new RelayCmd<IDialogWindow>(Yes, OnException);
            NoCommand = new RelayCmd<IDialogWindow>(No, OnException);
        }

        private void Yes(IDialogWindow window) => CloseDialogWithResult(window, true);
        private void No(IDialogWindow window) => CloseDialogWithResult(window, false);
    }
}
