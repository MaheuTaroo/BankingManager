using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingManagerDataLib.Models
{
    public abstract class Transaction
    {
        [Key]
        public virtual Guid TransactionId { get; }

        [ForeignKey(nameof(Account))]
        public virtual Guid AccountId { get; }
        public virtual Account Account { get; }
        public virtual decimal Amount { get; }
        public virtual DateTime DateTime { get; }
        public virtual string Description { get; set; }

        protected Transaction(Account account)
        {
            TransactionId = Guid.NewGuid();
            Account = account;
            AccountId = account.AccountId;
        }
#if DEBUG
        protected Transaction()
        {
            
        }
#endif
    }
}
