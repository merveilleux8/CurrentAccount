using CurrentAccount.DataAccess;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrentAccount.Service.Impl
{
    public class TransactionService : ITransactionService
    {
        private IMemoryCache _memoryCache;

        public TransactionService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Transaction AddTransaction(string accountId, double credit)
        {
            _memoryCache.TryGetValue("transactions", out Object result);
            var transactions = result as List<Transaction>;
            var transaction = new Transaction()
            {
                AccountId = accountId,
                Credit = credit
            };
            transactions.Add(transaction);
            _memoryCache.Set("transactions", transactions);
            return transaction;
        }

        public List<Transaction> GetTransactions(string accountId)
        {
            _memoryCache.TryGetValue("transactions", out Object result);
            var allTransactions = result as List<Transaction>;
            return allTransactions.Where(x => x.AccountId == accountId).ToList();
        }
    }
}
