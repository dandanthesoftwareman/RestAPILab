using RestAPILab.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        [HttpGet("OrderByCountry")]
        public List<Order> GetOrdersByCountry(string country)
        {
            return northwindContext.Orders.Where(o => o.ShipCountry == country).ToList();
        }

        [HttpGet("OrderByShipper")]
        public List<Order> GetOrdersByShipper(int shipper)
        {
            return northwindContext.Orders.Where(o => o.ShipVia == shipper).ToList();
        }
    }
}
