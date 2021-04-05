using System;

namespace CurrentAccount.DataAccess
{
    public class Transaction
    {
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        public string AccountId { get; set; }
        public double Credit { get; set; }
    }
}
