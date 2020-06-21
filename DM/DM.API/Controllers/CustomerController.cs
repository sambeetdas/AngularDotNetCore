using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DM.API.Filters;
using DM.API.IHandler;
using DM.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DM.API.Controllers
{
    [ServiceFilter(typeof(JwtFilter))]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _cust;
        public CustomerController(ICustomer cust)
        {
            _cust = cust;
        }
        [HttpPost]
        public Customer ProcessCustomer([FromBody] Customer customer)
        {
            return _cust.ProcessCustomer(customer);
        }

        [HttpDelete("{customerId}")]
        public string DeleteCustomer(string customerId)
        {
            return _cust.DeleteCustomer(customerId);
        }

        [HttpGet("{customerId}")]
        public Customer GetCustomerById(string customerId)
        {
            return _cust.GetCustomerById(customerId);
        }

        [HttpPost]
        public IEnumerable<Customer> SearchCustomer([FromBody] Customer customer)
        {
            return _cust.SearchCustomer(customer);

        }
    }
}