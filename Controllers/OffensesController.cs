using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PruebaInnovatioStrategies.Controllers
{
    public class PenaltyController : ApiController
    {
        public List<Penalty> ListPenalty = new List<Penalty >
        {
            new Penalty (1, "Exceso Velocidad", 3),
            new Penalty(2, "Aparcamiento", 2),
            new Penalty(3, "ITV caducada", 1)
        };

        // GET: Penalty
        public List<Penalty> Get()
        {
            return ListPenalty;
        }

        public Penalty Get(int id)
        {
            return ListPenalty.Find(penalty => penalty.Id == id);
        }

        public bool Post(int id, string description, int decreasePoint)
        {
            try
            {
                ListPenalty.Add(new Penalty(id, description, decreasePoint));
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}