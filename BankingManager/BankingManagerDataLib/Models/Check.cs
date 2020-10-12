using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace BankingManagerDataLib.Models
{
    public class Check : IEquatable<Check>
    {
        [Range(0, 2_097_152)] //2MB maximum file size. Image may be added after the transaction is posted.
        public byte[] ImageBytes { get; set; }
        public decimal Amount { get; }
        public DateTime Date { get; }
        [Range(0, int.MaxValue)]
        public int RoutingNumber { get; }
        [Range(0, int.MaxValue)]
        public int AccountNumber { get; }
        [Range(0, int.MaxValue)]
        public int CheckNumber { get; }
        public string Recipient { get; }

        public Check(decimal amount, string recipient, 
            int routingNumber, int accountNumber, int checkNumber, 
            DateTime dateTime)
        {
            Amount = amount;
            Recipient = recipient;
            RoutingNumber = routingNumber;
            AccountNumber = accountNumber;
            CheckNumber = checkNumber;
            Date = dateTime;
        }

        public bool Equals(Check other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && 
                   Date.Equals(other.Date) && 
                   RoutingNumber == other.RoutingNumber && 
                   AccountNumber == other.AccountNumber && 
                   CheckNumber == other.CheckNumber && 
                   Recipient == other.Recipient;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Check) obj);
        }

        public override int GetHashCode() => 
            HashCode.Combine(Amount, Date, RoutingNumber, AccountNumber, CheckNumber, Recipient);
    }
}
