using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        private DbController dbController = new DbController();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayCars()
        {
           var cars = dbController.GetCars();

            return View(cars);
        }
        //Change this
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}