using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Models
{
  
    public class Rental
    {
       
    

        public Rental(int id, int carId,string carName, string firstName, string lastName, string address, string city, string postCode, string phoneNumber, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            Id = id;
            CarId = carId;
            CarName = carName;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            PostCode = postCode;
            PhoneNumber = phoneNumber;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Rental( int carId, string carName, string firstName, string lastName, string address, string city, string postCode, string phoneNumber, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            CarId = carId;
            CarName = carName;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            PostCode = postCode;
            PhoneNumber = phoneNumber;
            StartDate = startDate;
            EndDate = endDate;
        }
        public int Id { get; set; }
        public int CarId { get; set; }
        [Required]
        public string CarName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        
        public string PostCode { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset EndDate { get; set; }
        public SelectList Cars { get; set; }
        public virtual Car Car { get; set; }
    }
}