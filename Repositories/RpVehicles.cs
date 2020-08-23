using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaInnovatioStrategies.Repositories
{
    public class RpVehicles
    {
        public static List<vehicle> ListVehicles = new List<vehicle>
        {
            new vehicle("7060GFD", "Renault", "Clio"),
            new vehicle("8960GTY", "Mercedes", "Clase C"),
            new vehicle("4561DGT", "Audi", "A3"),
            new vehicle("2645TRE", "Hyundai", "I30"),
        };

        public List<vehicle> GetVehicles()
        {
            return ListVehicles;
        }
        public vehicle GetVehicle(string matricula)
        {
            return ListVehicles.Where(vehicle => vehicle.Registration == matricula).FirstOrDefault();
        }

        public bool AddVehicle(vehicle newVehicle)
        {
            try
            {
                ListVehicles.Add(newVehicle);
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public bool checkExistVehicle(string registration)
        {
            return (ListVehicles.Find(vehicle => vehicle.Registration == registration)) != null;
        }
    }
}