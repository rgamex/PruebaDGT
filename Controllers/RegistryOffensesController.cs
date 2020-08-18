using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PruebaInnovatioStrategies.Controllers
{
    public class RegistryOffensesController : ApiController
    {
        public List<RegistryOffenses> ListOffenses = new List<RegistryOffenses>
        {
            new RegistryOffenses (new Offenses (1, "Exceso Velocidad", 3),new vehicle("7060GFD", "Renault", "Clio"),  new Driver("77336655J","Antonio", "García Lopez", 10), DateTime.Now ),
            new RegistryOffenses(new Offenses (2, "Aparcamiento", 2),new vehicle("8960GTY", "Mercedes", "Clase C"),  new Driver("25895620L", "Juan", "Perez Ballesteros", 8), DateTime.Now ),
            new RegistryOffenses (new Offenses (3, "ITV caducada", 1),new vehicle("4561DGT", "Audi", "A3"),  new Driver("78945612G", "Luisa", "Gámez Ruiz", 12), DateTime.Now ),
            new RegistryOffenses (new Offenses (1, "Exceso Velocidad", 3),new vehicle("7060GFD", "Renault", "Clio"),  new Driver("77336655J","Antonio", "García Lopez", 10), DateTime.Now )
        };

        [System.Web.Http.HttpGet]
        public List<RegistryOffenses>  GetDriverOffenses(string dni)
        {
            return ListOffenses.FindAll(registry => registry.Conductor.DNI == dni);
        }

        //[System.Web.Http.HttpGet]
        //public List<RegistryOffenses> GetMostCommonOffenses()
        //{
            //Dictionary<string, int> listRepeatsOffenses = new Dictionary<string, int>;
            //return ListOffenses.;
        //}
    }
}