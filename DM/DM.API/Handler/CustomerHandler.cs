using DM.API.IHandler;
using DM.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DM.API.Handler
{
    public class CustomerHandler : ICustomer
    {
        public string DeleteCustomer(string customerId)
        {
            return "Customer with Customer Id: " + customerId.ToString() + " is deleted.";
        }

        public Customer GetCustomerById(string customerId)
        {
            return new Customer
            {
                CustomerId = "12345",
                FirstName = "Sambeet",
                LastName = "Das",
                PhoneNumber = "9538754521",
                Address = "Bangalore",
                DateOfBirth = "13/07/1986"
            };
        }

        public Customer ProcessCustomer(Customer customer)
        {
            return new Customer
            {
                CustomerId = "12345",
                FirstName = "Sambeet New",
                LastName = "Das",
                PhoneNumber = "9538754521",
                Address = "Bangalore",
                DateOfBirth = "13/07/1986"
            };
        }

        public IEnumerable<Customer> SearchCustomer(Customer customer)
        {
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer
            {
                CustomerId = "12345",
                FirstName = "Sambeet",
                LastName = "Das",
                PhoneNumber = "9538754521",
                Address = "Bangalore",
                DateOfBirth = "13/07/1986"
            });
            customers.Add(new Customer
            {
                CustomerId = "1121212",
                FirstName = "Sambeet - New",
                LastName = "Das",
                PhoneNumber = "9538754521",
                Address = "Bhubaneswar",
                DateOfBirth = "13/07/1986"
            });
            return customers;
        }
    }
}
