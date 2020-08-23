using System;
using System.Collections.Generic;

namespace PruebaInnovatioStrategies
{
    public class vehicle
    {
        public string Registration { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public vehicle(string registration, string brand, string model)
        {
            Registration = registration;
            Brand = brand;
            Model = model;

        }
    }
}