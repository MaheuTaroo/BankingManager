namespace BankingManagerDataLib.Models
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(int routingNumber, int accountNumber, Customer customer) : 
            base(routingNumber, accountNumber, customer)
        {
            
        }
        public double InterestRate { get; set; }
    }
}
