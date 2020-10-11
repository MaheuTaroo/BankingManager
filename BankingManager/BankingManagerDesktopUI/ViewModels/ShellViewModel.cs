using System;
using System.Collections.Generic;
using System.Text;

namespace BankingManagerDesktopUI.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private string _windowTitle = "Banking Manager";
        public string WindowTitle
        {
            get => _windowTitle;
            set => Set(ref _windowTitle, value);
        }
    }
}
