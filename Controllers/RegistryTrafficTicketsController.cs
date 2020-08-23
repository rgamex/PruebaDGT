using PruebaInnovatioStrategies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PruebaInnovatioStrategies.Controllers
{
    public class RegistryTrafficTicketsController : ApiController
    {
        [HttpGet]
        public List<RegistryTrafficTicket>  GetDriverTrafficTickets(string dni)
        {
            RpRegistryTrafficTickets rpRegistry = new RpRegistryTrafficTickets();
            return rpRegistry.GetListRegistries().FindAll(registry => registry.Conductor.DNI == dni);
        }

        [HttpGet]
        public List<TrafficTicket> GetMostCommonTrafficTickets()
        {
            RpRegistryTrafficTickets rpRegistry = new RpRegistryTrafficTickets();
            return rpRegistry.GetMostCommonTrafficTickets();
        }

        [HttpGet]
        public List<Driver> GetTopDriversWithTrafficTickets(int amountDrivers)
        {
            RpRegistryTrafficTickets rpRegistry = new RpRegistryTrafficTickets();
            return rpRegistry.GetTopDriversWithTrafficTickets(amountDrivers);
        }

        [HttpPost]
        public bool AddRegistryTrafficTicket(TrafficTicket t, vehicle v, DateTime time)
        {
            RpRegistryTrafficTickets rpRegistry = new RpRegistryTrafficTickets();
            RpDrivers rpD = new RpDrivers();
            List<Driver> ListD = rpD.GetDrivers().ToList();
            Driver d = null;
            foreach (Driver driver in ListD)
            {
                foreach (vehicle car in driver.listVehicles )
                {
                    if (car.Registration == v.Registration)
                    {
                        d = driver;
                        break;
                    }
                }
            }

            if (d != null)
            {
                return rpRegistry.AddRegistryTrafficTicket(t, v, d, time);
            } else
            {
                //TODO mandar mensaje error
                return false;
            }
            
        }
    }
}