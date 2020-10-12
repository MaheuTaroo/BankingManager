using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public Customer Customer
        {
            get => _customer;
            set => Set(ref _customer, value);
        }

        private readonly SampleDataService _sampleDataService;
        private Customer _customer;
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
