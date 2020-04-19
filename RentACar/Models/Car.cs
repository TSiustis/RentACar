using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class Car
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public int NumberOfDoors { get; set; }
        public int NumberOfSeats { get; set; }
        public Car(int year, string make, string model, string color)
        {
            Year = year;
            Make = make;
            Model = model;
            Color = color;
        }
    }
}