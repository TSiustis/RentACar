using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class RentalController : Controller
    {
        DbController dbConnection = new DbController();
        // GET: Rental
      [Authorize]
        public ActionResult Index()
        {
            //List<Rental> Rentals = dbConnection.GetRentals();

            //ViewBag.Rentals = Rentals;
            return View();
        }
        // GET: Rental/Details/5
        public ActionResult Details(int id)
        {
           // List<Rental> Rentals = dbConnection.GetRentals();
            //var rental = Rentals.Where(c => c.Id == id);
            //ViewBag.Rental = rental;
            return View();
        }

        // GET: Rental/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rental/Create
        //[HttpPost]
        //public ActionResult Create()
        //{
        //    try
        //    {
        //        dbConnection.InsertRental(ViewBag.Year, ViewBag.Make, ViewBag.Model, ViewBag.StartDate, ViewBag.EndDate);

        //        return RedirectToAction("Confirmation");
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }
        //}
        [HttpPost]
        public ActionResult InsertRental()
        {
            //try
            //{
                dbConnection.InsertRental(ViewBag.Year, ViewBag.Make, ViewBag.Model, ViewBag.StartDate, ViewBag.EndDate);

                return View("Confirmation");
            //}
            //catch
            //{
            //    return View("Error");
            //}
        }
        // GET: Rental/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rental/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rental/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rental/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
