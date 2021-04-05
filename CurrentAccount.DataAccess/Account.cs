using System;

namespace CurrentAccount.DataAccess
{
    public class Account
    {
        public int CustomerId { get; set; }
        public string AccountId { get; set; } = Guid.NewGuid().ToString();
    }
}
