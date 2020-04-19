using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
  
    public class Rental
    {
       
        public Rental(int carId, int customerId, DateTimeOffset startDate, DateTimeOffset endDate, Customer customer, Car car)
        {
            CarId = carId;
            CustomerId = customerId;
            StartDate = startDate;
            EndDate = endDate;
            Customer = customer;
            Car = car;
        }
       
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
    }
}