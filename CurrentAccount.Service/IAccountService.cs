using CurrentAccount.Data;
using CurrentAccount.DataAccess;
using System;
using System.Collections.Generic;

namespace CurrentAccount.Service
{
    public interface IAccountService
    {
        Account AddAccount(int customerId, double initialCredit);
        List<Account> GetAccounts();
        CustomerAccount GetAccountCustomer(int customerId);
    }
}
