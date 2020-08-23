using System;

namespace PruebaInnovatioStrategies
{
    public class RegistryTrafficTicket
    {
        public int Id { get; set; }
        public TrafficTicket Infraccion { get; set; }

        public vehicle Vehiculo { get; set; }

        public Driver Conductor { get; set; }

        public DateTime Fecha { get; set; }

        public RegistryTrafficTicket(int id, TrafficTicket TfTicket, vehicle car, Driver driver, DateTime fecha)
        {
            Id = id;
            Infraccion = TfTicket;
            Vehiculo = car;
            Conductor = driver;
            Fecha = fecha;

            discountDriverPoints(TfTicket, driver);
        }

        public void discountDriverPoints (TrafficTicket tfTicket, Driver driver)
        { 
            driver.ChangePoint(KindOfOperation.DECREASE, tfTicket.DecreasePoint);
        }
    }
}