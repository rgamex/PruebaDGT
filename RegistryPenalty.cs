using System;

namespace PruebaInnovatioStrategies
{
    public class RegistryPenalty
    {
        public Penalty Infraccion { get; set; }

        public vehicle Vehiculo { get; set; }

        public Driver Conductor { get; set; }

        public DateTime Fecha { get; set; }

        public RegistryOffenses(Penalty penalty, vehicle car, Driver driver, DateTime fecha)
        {
            Infraccion = penalty;
            Vehiculo = car;
            Conductor = driver;
            Fecha = fecha;

            discountDriverPoints(penalty, driver);
        }

        public void discountDriverPoints (Penalty penalty, Driver driver)
        { 
            driver.ChangePoint(KindOfOperation.DECREASE, penalty.DecreasePoint);
        }
    }
}