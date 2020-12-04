using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_frontendd.Controllers
{
    public class DestinationsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SuccessBody = ApiCalls.GetDestinationFlights();
            return View();
        }
    }
}
