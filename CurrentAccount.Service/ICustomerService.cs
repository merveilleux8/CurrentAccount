using CurrentAccount.DataAccess;
using System;
using System.Collections.Generic;

namespace CurrentAccount.Service
{
    public interface ICustomerService
    {
        bool CheckIfCustomerExists(int customerId);
        Customer GetCustomer(int customerId);
    }
}
