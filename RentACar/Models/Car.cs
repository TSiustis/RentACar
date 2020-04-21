using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class Car
    {
        public int Id;
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public int NumberOfDoors { get; set; }
        public int NumberOfSeats { get; set; }
        public Car(int id, int year, string make, string model, string color)
        {
            Id = id;
            Year = year;
            Make = make;
            Model = model;
            Color = color;
        }
    }
}