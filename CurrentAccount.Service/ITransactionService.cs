using CurrentAccount.DataAccess;
using System;
using System.Collections.Generic;

namespace CurrentAccount.Service
{
    public interface ITransactionService
    {
        Transaction AddTransaction(string accountId, double credit);
        List<Transaction> GetTransactions(string accountId);
    }
}
