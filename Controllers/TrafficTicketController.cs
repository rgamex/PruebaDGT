using PruebaInnovatioStrategies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;

namespace PruebaInnovatioStrategies.Controllers
{
    public class TrafficTicketController : ApiController
    {
        // GET: TrafficTicket
        [HttpGet]
        public List<TrafficTicket> GetTrafficTickets()
        {
            RpTrafficTickets rpTrafficTickets = new RpTrafficTickets();
            return rpTrafficTickets.GetTrafficTickets().ToList();
        }

        [HttpGet]
        public TrafficTicket GetTrafficTicket(int id)
        {
            RpTrafficTickets rpTrafficTickets = new RpTrafficTickets();
            return rpTrafficTickets.GetTrafficTicket(id);
        }

        [HttpPost]
        public bool AddTrafficTicket(int id, string description, int decreasePoint)
        {
            RpTrafficTickets rpTrafficTickets = new RpTrafficTickets();
            TrafficTicket ticket = new TrafficTicket(id, description, decreasePoint);

            return rpTrafficTickets.AddTrafficTicket(ticket);
        }
    }
}