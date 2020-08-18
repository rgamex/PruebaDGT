using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaInnovatioStrategies.Controllers
{
    public class DriversController : ApiController
    {
        public List<Driver> ListDriver = new List<Driver>
        {
            new Driver("77336655J","Antonio", "García Lopez", 10),
            new Driver("25895620L", "Juan", "Perez Ballesteros", 8),
            new Driver("74465230H", "María", "Rodriguez Aro", 10),
            new Driver("78945612G", "Luisa", "Gámez Ruiz", 12)
        };

        // GET api/values
        public IEnumerable<Driver> Get()
        {
            return ListDriver;
        }

        // GET api/values/5
        public Driver Get(string DNI)
        {
            return ListDriver.Find(driver => driver.DNI == DNI);
        }

        // POST api/values
        public bool Post([FromBody]string dni, string name, string lastName, int point)
        {
            if (!checkExistDNI(dni))
            {
                try
                {
                    ListDriver.Add(new Driver(dni, name, lastName, point));
                } catch (Exception ex)
                {
                    return false;
                }

                return true;
            } else
            {
                return false;
            }

        }

        public bool checkExistDNI (string DNI)
        {
            return (ListDriver.Find(drive => drive.DNI == DNI)) != null;
        }
    }
}
