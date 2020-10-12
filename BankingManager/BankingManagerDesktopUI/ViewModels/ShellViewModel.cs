using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BankingManagerDesktopUI.Commands;
using BankingManagerDesktopUI.Models;
using BankingManagerDesktopUI.Services;

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

        public Navigator Navigator { get; }
        private readonly IDialogService _dialogService;
        public ICommand TryCloseCommand { get; }

        public ShellViewModel(IDialogService dialogService, Navigator navigator, HomeViewModel homeViewModel)
        {
            _dialogService = dialogService;
            Navigator = navigator;
            Navigator.TryAddViewModel(ViewType.HomeView, homeViewModel);
            Navigator.TryAddViewModel(ViewType.AboutView, new AboutViewModel());

            TryCloseCommand = new RelayCmd(TryClose, OnException);
        }

        private void TryClose()
        {
            var dialog = new YesNoViewModel(_windowTitle,
                "Are you sure you want to exit Banking Manager?");

            if (_dialogService.OpenDialog(dialog) == true)
                Environment.Exit(0);
        }
    }
}
