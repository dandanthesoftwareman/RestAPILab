using RestAPILab.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        [HttpGet("GetCustomerByCity")]
        public List<Customer> GetCustomerByCity(string city)
        {
            return northwindContext.Customers.Where(c => c.City == city).ToList();
        }

        [HttpGet("GetCustomerByName")]
        public List<Customer> GetCustomerByName(string name)
        {
            return northwindContext.Customers.Where(c => c.ContactName == name).ToList();
        }
        [HttpPost("AddCustomer")]
        public Customer AddCustomer(string custId, string companyName, string contactName, string contactTitle, string address, string city, string postalCode, string country, string phone, string fax)
        {
            Customer customer = new Customer()
            {
                CustomerId = custId,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };
            northwindContext.Customers.Add(customer);
            northwindContext.SaveChanges();
            return customer;
        }
    }
}
