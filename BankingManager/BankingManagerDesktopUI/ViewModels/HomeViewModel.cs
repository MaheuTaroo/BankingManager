using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BankingManagerDataLib.Models;
using BankingManagerDataLib.Services;
using BankingManagerDesktopUI.Commands;

namespace BankingManagerDesktopUI.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set => Set(ref _customers, value);
        }

        private readonly SampleDataService _sampleDataService;
        public ICommand LoadAsyncCommand { get; }

#if DEBUG
        public HomeViewModel(SampleDataService sampleDataService) : this()
        {
            _sampleDataService = sampleDataService;
        }

        private async Task LoadAsync()
        {
            var customers = await _sampleDataService.GetSampleCustomersAsync();
            Customers = new ObservableCollection<Customer>(customers);
        }
#endif
        public HomeViewModel()
        {
            LoadAsyncCommand = new AsyncRelayCmd(LoadAsync, OnException);
        }

    }
}
