using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BankingManagerDataLib.Models;

namespace BankingManagerDataLib.Services
{
    public class SampleDataService
    {
        private const string DataPath = "./SampleData/";

        public async Task<IEnumerable<Customer>> GetSampleCustomersAsync()
        {
            await using var stream = File.OpenRead(DataPath + "SampleCustomers.json");
            return await JsonSerializer.DeserializeAsync<List<Customer>>(stream);
        }

        public async Task<IEnumerable<Transaction>> GetSampleTransactionsAsync()
        {
            await using var stream = File.OpenRead(DataPath + "SampleTransactions.json");
            return await JsonSerializer.DeserializeAsync<List<Transaction>>(stream);
        }
    }
}
