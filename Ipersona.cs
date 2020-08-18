using System;

namespace PruebaInnovatioStrategies
{
    public interface Iperson
    {
        String DNI { get; set; }
        String Name { get; set; }
        String LastName { get; set; }
        String GetFullName();
    }
}