using System.Collections.Generic;

namespace PruebaInnovatioStrategies
{
    public enum KindOfOperation
    {
        INCREASE,
        DECREASE
    }

    public class Driver : Iperson
    {
        public string DNI { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }

        public int Point { get; set; }
        public List<vehicle> listVehicles { get; }

        public Driver(string dni, string name, string lastName, int point)
        {
            DNI = dni;
            Name = name;
            LastName = lastName;
            Point = point;
        }

        public string GetFullName()
        {
            return Name + " " + LastName;
        }

        public void ChangePoint(KindOfOperation operation, int points)
        {
            if (operation == KindOfOperation.INCREASE)
            {
                this.Point += points; 
            } else if (operation == KindOfOperation.DECREASE) {
                this.Point -= points;
            }
        }

        public bool addVehicle (vehicle car)
        {
            if(this.listVehicles.Count < 10)
            {
                listVehicles.Add(car);
                return true;
            } else
            {
                return false;
            }
        }
    }
}