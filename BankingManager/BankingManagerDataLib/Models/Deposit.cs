using System.Collections.Generic;
using System.Linq;

namespace BankingManagerDataLib.Models
{
    public class Deposit : Transaction
    {
        public ICollection<Check> Checks { get; }
        public decimal Cash { get; }
        public override decimal Amount => Checks.Sum(check => check.Amount) + Cash;
        public Deposit(ICollection<Check> checks, decimal cash, Account account) : base(account)
        {
            Checks = checks;
            Cash = cash;
        }
    }
}
