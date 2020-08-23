using PruebaInnovatioStrategies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;

namespace PruebaInnovatioStrategies.Controllers
{
    public class DriversController : ApiController
    {

        // GET api/values
        [HttpGet]
        public List<Driver> GetDrivers()
        {
            RpDrivers rpDrivers = new RpDrivers();
            return rpDrivers.GetDrivers().ToList();
        }

        //GET api/Drivers/GetDrivers/
        [HttpGet()]
        public Driver GetDriver(string DNI)
        {
            RpDrivers rpDrivers = new RpDrivers();
            return rpDrivers.GetDriver(DNI);
        }

        // POST api/values
        [HttpPost]
        public bool AddDriver(string dni, string name, string lastName, int point)
        {
            RpDrivers rpDrivers = new RpDrivers();

            if (!rpDrivers.checkExistDNI(dni))
            {
                Driver NewDriver = new Driver(dni, name,lastName,point);
                return rpDrivers.AddDriver(NewDriver);
            } else
            {
                return false;
            }
        }
    }
}
