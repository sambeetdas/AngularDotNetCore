using DM.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DM.API.IHandler
{
    public interface ICustomer
    {
        Customer ProcessCustomer(Customer customer);
        string DeleteCustomer(string customerId);
        Customer GetCustomerById(string customerId);
        IEnumerable<Customer> SearchCustomer(Customer customer);
    }
}
