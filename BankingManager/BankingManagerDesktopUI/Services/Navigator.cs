using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using BankingManagerDataLib.Helpers;
using BankingManagerDesktopUI.Commands;
using BankingManagerDesktopUI.Models;
using BankingManagerDesktopUI.ViewModels;

namespace BankingManagerDesktopUI.Services
{
    public class Navigator : Observable
    {
        private BaseViewModel _activeViewModel;
        private readonly Dictionary<ViewType, BaseViewModel> _viewModels;
        public BaseViewModel ActiveViewModel
        {
            get => _activeViewModel;
            set => Set(ref _activeViewModel, value);
        }

        public ICommand NavigateToCommand { get; }

        public Navigator()
        {
            _viewModels = new Dictionary<ViewType, BaseViewModel>();
            NavigateToCommand = new RelayCmd<ViewType>(NavigateTo, ex => Debug.Print(ex.ToString()));
        }

        public bool TryAddViewModel(ViewType viewType, BaseViewModel viewModel)
        {
            return _viewModels.TryAdd(viewType, viewModel);
        }

        private void NavigateTo(ViewType viewType)
        {
            try
            {
                ActiveViewModel = _viewModels[viewType];
            }
            catch (KeyNotFoundException ex)
            {
                Debug.Print(ex.ToString());
            }
        }
    }
}
