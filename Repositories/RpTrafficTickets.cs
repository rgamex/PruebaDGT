using PruebaInnovatioStrategies.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PruebaInnovatioStrategies.Repositories
{
    public class RpTrafficTickets
    {
        public static List<TrafficTicket> ListTrafficTickets = new List<TrafficTicket>
        {
            new TrafficTicket (1, "Exceso Velocidad", 3),
            new TrafficTicket(2, "Aparcamiento", 2),
            new TrafficTicket(3, "ITV caducada", 1)
        };

        public IEnumerable<TrafficTicket> GetTrafficTickets()
        {
            return ListTrafficTickets;
        }
        
        public TrafficTicket GetTrafficTicket(int id)
        {
            return ListTrafficTickets.Where(ticket => ticket.Id == id).FirstOrDefault();
        }

        public bool AddTrafficTicket(TrafficTicket newTrafficTicket)
        {
            try
            {
                ListTrafficTickets.Add(newTrafficTicket);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetNewId()
        {
            return ListTrafficTickets.Last().Id + 1;
        }
    }
}