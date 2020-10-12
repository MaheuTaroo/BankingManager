using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankingManagerDataLib.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        //One-to-many relationship
        public ICollection<Account> Accounts { get; set; }
    }
}
