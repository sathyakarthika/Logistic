using Business;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Logistics.Controllers
{
    public class LogisticsController : ApiController
    {
        public List<City> GetCity()
        {
            Logistic objLogistic = new Logistic();
            return objLogistic.GetCity();
        }

        public List<Kg> GetKg()
        {
            Logistic objLogistic = new Logistic();
            return objLogistic.GetKg();
        }

        public string getZone(int City1, int City2)
        {
            Logistic objLogistic = new Logistic();
            return objLogistic.GetZone(City1, City2);
        }

        public string getValueByZone(string Zone, int Kg)
        {
            Logistic objLogistic = new Logistic();
            return objLogistic.getValueByZone(Zone, Kg);
        }
    }
}
