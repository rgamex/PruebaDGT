using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PruebaInnovatioStrategies.Controllers
{
    public class VehicleController : ApiController
    {
        public List<vehicle> ListVehicles = new List<vehicle>
        {
            new vehicle("7060GFD", "Renault", "Clio"),
            new vehicle("8960GTY", "Mercedes", "Clase C"),
            new vehicle("4561DGT", "Audi", "A3"),
            new vehicle("2645TRE", "Hyundai", "I30"),
        };
        // GET: Vehicle
        public List<vehicle> Get()
        {
            return ListVehicles ;
        }

        public vehicle Get(string registration)
        {
            return ListVehicles.Find(vehicle => vehicle.Registration == registration);
        }

        public bool Post(string registration, string brand, string model, string dni)
        {
            DriversController controlDriver = new DriversController();
            if (!(checkExistVehicle(registration)) && (controlDriver.checkExistDNI(dni)))
            {
                try
                {
                    Driver conductor = controlDriver.Get(dni);
                    vehicle car = new vehicle(registration, brand, model);
                    if (conductor.addVehicle(car)) {
                        ListVehicles.Add(car);
                    } else
                    {
                        throw new Exception();
                    }                 
                }
                catch (Exception ex)
                {
                    return false;
                }

                return true;
            }
            else
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