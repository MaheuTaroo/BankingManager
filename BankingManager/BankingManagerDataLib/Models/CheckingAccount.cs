using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankingManagerDataLib.Models
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(int routingNumber, int accountNumber, Customer customer) : 
            base(routingNumber, accountNumber, customer)
        {
            
        }
        //Retrieves a collection of checks associated with a Checking account;
        public ICollection<Check> Checks { get; set; }
    }
}
