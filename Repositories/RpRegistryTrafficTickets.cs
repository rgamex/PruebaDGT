using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Generator;

namespace PruebaInnovatioStrategies.Repositories
{
    public class RpRegistryTrafficTickets
    {
        private static List<TrafficTicket> listTfTickets = RpTrafficTickets.ListTrafficTickets;
        private static List<vehicle> listVehicle = RpVehicles.ListVehicles;
        private static List<Driver> listDriver = RpDrivers.ListDriver; 

        public List<RegistryTrafficTicket> ListRegistryTrafficTickets = new List<RegistryTrafficTicket>
        {
            new RegistryTrafficTicket (1, listTfTickets[0], listVehicle[0],  listDriver[0], DateTime.Now ),
            new RegistryTrafficTicket (2, listTfTickets[1], listVehicle[1],  listDriver[1], DateTime.Now ),
            new RegistryTrafficTicket (3, listTfTickets[2], listVehicle[2],  listDriver[2], DateTime.Now ),
            new RegistryTrafficTicket (4, listTfTickets[0], listVehicle[0],  listDriver[0], DateTime.Now ),
            new RegistryTrafficTicket (5, listTfTickets[1], listVehicle[0],  listDriver[0], DateTime.Now ),
            new RegistryTrafficTicket (6, listTfTickets[1], listVehicle[1],  listDriver[1], DateTime.Now ),
            new RegistryTrafficTicket (7, listTfTickets[1], listVehicle[2],  listDriver[2], DateTime.Now ),
        };

        public List<RegistryTrafficTicket> GetListRegistries()
        {
            return ListRegistryTrafficTickets.ToList();
        }

        public RegistryTrafficTicket GetListRegistrie(int id)
        {
            return ListRegistryTrafficTickets.Where(registry=> registry.Id == id).FirstOrDefault();
        }

        public bool AddRegistryTrafficTicket(TrafficTicket t, vehicle v, Driver d, DateTime time)
        {
            try
            {
                RegistryTrafficTicket newRegistry = new RegistryTrafficTicket(this.GetNewIdRegistry(), t, v, d, time);
                ListRegistryTrafficTickets.Add(newRegistry);
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public int GetNewIdRegistry()
        {
            return ListRegistryTrafficTickets.Last().Id + 1;
        }

        public List<TrafficTicket> GetMostCommonTrafficTickets()
        {
            Dictionary<int, int> listMostCommonAux = new Dictionary<int, int>();

            foreach (RegistryTrafficTicket registry in ListRegistryTrafficTickets)
            {
                int count;
                listMostCommonAux.TryGetValue(registry.Infraccion.Id, out count);
                count++;
                listMostCommonAux[registry.Infraccion.Id] = count;
            }

            listMostCommonAux = listMostCommonAux.ToList().OrderByDescending(item => item.Value).Take(5)
                .ToDictionary(item => item.Key, item => item.Value);

            List<TrafficTicket> listMostCommon = new List<TrafficTicket>();

            foreach (KeyValuePair<int, int> registry in listMostCommonAux)
            {
                TrafficTicket trafficTicket = ListRegistryTrafficTickets.Find(item => item.Infraccion.Id == registry.Key).Infraccion;
                listMostCommon.Add(trafficTicket);
            }

            return listMostCommon;
        }

        public List<Driver> GetTopDriversWithTrafficTickets(int amountDrivers)
        {
            Dictionary<string, int> listTopDriversAux = new Dictionary<string, int>();

            foreach (RegistryTrafficTicket registry in ListRegistryTrafficTickets)
            {
                int count;
                listTopDriversAux.TryGetValue(registry.Conductor.DNI, out count);
                count++;
                listTopDriversAux[registry.Conductor.DNI] = count;
            }


            listTopDriversAux = listTopDriversAux.ToList().OrderByDescending(item => item.Value).Take(amountDrivers)
                .ToDictionary(item => item.Key, item => item.Value);

            List<Driver> listTopDriver = new List<Driver>();

            foreach (KeyValuePair<string, int> registry in listTopDriversAux)
            {
                Driver driver = ListRegistryTrafficTickets.Find(item => item.Conductor.DNI == registry.Key).Conductor;
                listTopDriver.Add(driver);
            }

            return listTopDriver;
        }

    }
}