using Microsoft.AspNet.Identity;
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
            List<Rental> ListOfRentals = new List<Rental>();
            ListOfRentals = dbConnection.GetRentals();
            string[] arr = User.Identity.GetUserId().Split();
            int Id;
            Int32.TryParse(arr[0],out Id);
            var myRent = ListOfRentals.Where(c => c.Id==Id);
            if (myRent.Count() > 0)
            {
                ViewBag.Shown = true;
            }
            else
                ViewBag.Shown = false;
            ViewBag.Id = Id;
            return View();
        }

        public ActionResult Create()
        {
            var cars = dbConnection.GetCars();
           ViewBag.ListMake =
                new SelectList(dbConnection.GetCars()
                .Select(x => new { value = x.Id, text = x.Make + " " + x.Model + " " + x.Year }).Distinct(),"Value","Text");
         
            

                return View();
        }

      
     
        [HttpPost]
        public ActionResult Confirmation(int? Id, FormCollection form,int? CarId,string CarName, DateTimeOffset StartDate, DateTimeOffset EndDate, string FirstName, string LastName, string  Address, string City,string PostCode, string PhoneNumber)
        {
            //  CarId = (int)ListMake.Where(x => x.Selected).FirstOrDefault();
            double Total = 0, DaysUse;
            DaysUse =(EndDate - StartDate).TotalDays; 
            if (CarName.Equals("Toyota"))
            {
                Total += (22.99 * DaysUse);
            }
            else if (CarName.Equals("Audi"))
            {
                Total += (30 * DaysUse);
            }
            else
                Total = (50 * DaysUse);
            ViewBag.Total = Total;
            ViewBag.DaysUse = DaysUse;
           
            int CarIdd;
             Int32.TryParse(form["ListMake"],out CarIdd);
            CarName = form["CarName"];
            ViewBag.CarName = CarName;
            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;
            
            if (ModelState.IsValid)
            {
                dbConnection.InsertRental(CarIdd, CarName, FirstName, LastName, Address, City, PostCode, PhoneNumber, StartDate, EndDate);
                return View();
            }
            else
                return View("Confirmation");
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
        public ActionResult Details(int id)
        {
            List<Rental> ListOfRentals = new List<Rental>();
            ListOfRentals = dbConnection.GetRentals();

            var rentDetails = ListOfRentals.Where(c=>c.Id == id);

            ViewBag.ListOfRent = rentDetails;
            ViewBag.Id = id;
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
