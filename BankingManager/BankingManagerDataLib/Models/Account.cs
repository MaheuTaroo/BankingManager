using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BankingManagerDataLib.Models
{
    public abstract class Account
    {
        [Key]
        public virtual Guid AccountId { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public virtual double MonthlyServiceFee { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public int RoutingNumber { get; }
        public int AccountNumber { get; }
        public decimal Balance => Transactions.Sum(transaction => transaction.Amount);
        protected Account(int routingNumber, int accountNumber, Customer customer)
        {
            CustomerId = customer.CustomerId;
            Customer = customer;

            RoutingNumber = routingNumber;
            AccountNumber = accountNumber;
        }
    }
}