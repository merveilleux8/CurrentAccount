using CurrentAccount.DataAccess;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrentAccount.Service.Impl
{
    public class CustomerService : ICustomerService
    {
        private IMemoryCache _memoryCache;

        public CustomerService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public bool CheckIfCustomerExists(int customerId)
        {
            _memoryCache.TryGetValue("customers", out Object result);
            var customers = result as List<Customer>;
            return customers.Any(x => x.CustomerId == customerId);
        }

        public Customer GetCustomer(int customerId)
        {
            _memoryCache.TryGetValue("customers", out Object result);
            var customers = result as List<Customer>;
            return customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
        }
    }
}
