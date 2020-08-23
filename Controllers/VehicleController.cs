using PruebaInnovatioStrategies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PruebaInnovatioStrategies.Controllers
{
    public class VehicleController : ApiController
    {

        // GET: Vehicle
        [HttpGet]
        public List<vehicle> GetVehicles()
        {
            RpVehicles rpVehicles = new RpVehicles();
            return rpVehicles.GetVehicles();
        }

        [HttpGet]
        public vehicle GetVehicle(string registration)
        {
            RpVehicles rpVehicles = new RpVehicles();
            return rpVehicles.GetVehicle(registration);
        }

        [HttpPost]
        public bool AddVehicleToDrive(string registration, string brand, string model, string dni)
        {
            RpVehicles rpVehicle = new RpVehicles();
            RpDrivers rpDrivers = new RpDrivers();
            try
            {
                //TODO Validar matrícula antes de agregar el vehículo rpVehicle.AddVehicle
                if (!rpVehicle.checkExistVehicle(registration) && rpDrivers.checkExistDNI(dni))
                {
                        Driver conductor = rpDrivers.GetDriver(dni);
                        vehicle car = new vehicle(registration, brand, model);
                        if (rpVehicle.AddVehicle(car)) {
                            return conductor.addVehicle(car);
                        } else
                        {
                            throw new Exception();
                        }                 
                }
                else
                {
                    return false;
                }
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}