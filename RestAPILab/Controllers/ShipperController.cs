using RestAPILab.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        [HttpGet("GetShipperById")]
        public Shipper GetShipperById(int id)
        {
            return northwindContext.Shippers.FirstOrDefault(x => x.ShipperId == id);
        }
        [HttpGet("GetShipperByPhone")]
        public Shipper GetShipperByPhone(string phone)
        {
            return northwindContext.Shippers.FirstOrDefault(x => x.Phone == phone);
        }
        [HttpPost("AddShipper")]
        public Shipper AddShipper(int id, string name, string phone)
        {
            Shipper shipper = new Shipper()
            {
                ShipperId = id,
                CompanyName = name,
                Phone = phone
            };
            northwindContext.Shippers.Add(shipper);
            northwindContext.SaveChanges();
            return shipper;
        }
        [HttpDelete("RemoveShipper")]
        public Shipper RemoveShipper(int id)
        {
            Shipper s = northwindContext.Shippers.FirstOrDefault(x => x.ShipperId == id);
            northwindContext.Shippers.Remove(s);
            northwindContext.SaveChanges();
            return s;
        }
    }
}
