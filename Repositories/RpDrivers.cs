using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaInnovatioStrategies.Repositories
{
    public class RpDrivers
    {
        public static List<Driver> ListDriver = new List<Driver>
        {
            new Driver("77336655J","Antonio", "García Lopez", 10, RpVehicles.ListVehicles[0]),
            new Driver("25895620L", "Juan", "Perez Ballesteros", 8, RpVehicles.ListVehicles[1]),
            new Driver("74465230H", "María", "Rodriguez Aro", 10, RpVehicles.ListVehicles[2]),
            new Driver("78945612G", "Luisa", "Gámez Ruiz", 12, RpVehicles.ListVehicles[3])
        };

        public IEnumerable<Driver> GetDrivers()
        {
            return ListDriver;
        }

        public Driver GetDriver(String dni)
        {
            return ListDriver.Where(driver => driver.DNI == dni).FirstOrDefault();
        }

        public bool AddDriver(Driver newDriver)
        {
            try
            {
                ListDriver.Add(newDriver);
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public bool checkExistDNI(string DNI)
        {
            return (ListDriver.Find(drive => drive.DNI == DNI)) != null;
        }

        public bool checkDAvailabilityCVehicle(string matricula)
        {
            bool usedVehicle = false;

            foreach (Driver driver in ListDriver)
            {
                foreach (vehicle v in driver.listVehicles)
                {
                    if (v.Registration == matricula )
                    {
                        usedVehicle = true;
                        break;
                    }
                }
            }
            return usedVehicle;
        }
    }
}