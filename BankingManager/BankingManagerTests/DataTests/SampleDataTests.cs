using System.Linq;
using System.Threading.Tasks;
using BankingManagerDataLib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankingManagerTests.DataTests
{
    [TestClass]
    public class SampleDataTests
    {
        public SampleDataTests()
        {
            _sampleDataService = new SampleDataService();
        }

        private readonly SampleDataService _sampleDataService;
        [TestMethod]
        public async Task SampleDataDeserializes()
        {
            var customers = await _sampleDataService.GetSampleCustomersAsync();
            Assert.IsTrue(customers.Count() == 1000);
        }
    }
}
