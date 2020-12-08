using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_frontendd.Controllers
{
    public class PlanesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.table1 = ApiCalls.GetManufacturers200();
            ViewBag.table2 = ApiCalls.GetManufacturersFlights();
            ViewBag.table3 = ApiCalls.GetAirbuses();
            return View();
        }
    }
}
