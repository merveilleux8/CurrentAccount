using CurrentAccount.Data;
using CurrentAccount.DataAccess;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrentAccount.Service.Impl
{
    public class AccountService : IAccountService
    {
        private IMemoryCache _memoryCache;
        private ITransactionService _transactionService;
        private ICustomerService _customerService;

        public AccountService(IMemoryCache memoryCache, ITransactionService transactionService, ICustomerService customerService)
        {
            _memoryCache = memoryCache;
            _transactionService = transactionService;
            _customerService = customerService;
        }

        public Account AddAccount(int customerId, double initialCredit)
        {
            var account = new Account()
            {
                CustomerId = customerId
            };
            _memoryCache.TryGetValue("accounts", out Object result);
            var accounts = result as List<Account>;
            accounts.Add(new Account()
            {
                CustomerId = customerId
            });
            _memoryCache.Set("accounts", accounts);

            if(initialCredit>0)
            {
                _transactionService.AddTransaction(account.AccountId, initialCredit);
            }
            return account;
        }

        public List<Account> GetAccounts()
        {
            _memoryCache.TryGetValue("accounts", out Object result);
            return result as List<Account>;
        }

        public CustomerAccount GetAccountCustomer(int customerId)
        {
            _memoryCache.TryGetValue("accounts", out Object result);
            var accounts = result as List<Account>;
            var account = accounts.Where(x => x.CustomerId == customerId).FirstOrDefault();
            var customer = _customerService.GetCustomer(customerId);
            var customerAccount = new CustomerAccount() { AccountId=account.AccountId, CustomerId=customerId, Name=customer.Name, Surname=customer.Surname};
            return customerAccount;
        }



    }
}
