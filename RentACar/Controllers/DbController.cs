using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class DbController
    {
        private SqlConnection connString = new SqlConnection();
        public DbController()
        {
            connString.ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        //Gets Cars from SQL Database
        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            string SelectCommand = "SELECT * FROM Car;";
            connString.Open();
            SqlCommand sqlCommand = connString.CreateCommand();
            sqlCommand.CommandText = SelectCommand;
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                int id = (int)sqlReader["Id"];
                int year = (int)sqlReader["Year"];
                string make = (string)sqlReader["Make"];
                string model = (string)sqlReader["Model"];
                string color = (string)sqlReader["Color"];

                cars.Add(new Car(id,year, make, model, color));

                
            }
            connString.Close();
            return cars;
            
        }
        //Gets Rentals from SQL Database
        public List<Rental> GetRentals()
        {
            List<Rental> rentals = new List<Rental>();
            string SelectCommand = "SELECT * FROM Rental;";
            connString.Open();
            SqlCommand sqlCommand = connString.CreateCommand();
            sqlCommand.CommandText = SelectCommand;
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                int id = (int)sqlReader["Id"];
                int carId = (int)sqlReader["CarId"];
                string carName = (string)sqlReader["CarName"];
                string firstName = (string)sqlReader["FirstName"];
                string lastName = (string)sqlReader["LastName"];
                string address = (string)sqlReader["Address"];
                string city = (string)sqlReader["City"];
                string postCode = (string)sqlReader["PostCode"];
                string phoneNumber = (string)sqlReader["PhoneNumber"];
                DateTimeOffset startDate = (DateTimeOffset)sqlReader["StartDate"];
                DateTimeOffset endDate = (DateTimeOffset)sqlReader["EndDate"];

                rentals.Add(new Rental(id,carId,carName,firstName,lastName,address,city,postCode,phoneNumber,startDate,endDate));


            }
            connString.Close();
            return rentals;

        }
        public bool InsertRental(int CarId,string CarName,string FirstName, string LastName, string Address,string City, string PostCode, string PhoneNumber,  DateTimeOffset StartDate, DateTimeOffset EndDate)
        {
            string insertSql = "Insert into Rental(CarId,CarName,StartDate,EndDate,FirstName,LastName,Address,City,PostCode,PhoneNumber)";
            insertSql += "VALUES('" + CarId + "', '" + CarName + "', '" + StartDate + "','" +EndDate + "','" + FirstName + "', '" + LastName + "', '" + Address + "', '" + City + "', '" + PostCode + "', '" +  PhoneNumber + "')";
            connString.Open();
            SqlCommand sqlCommand = connString.CreateCommand();
            sqlCommand.CommandText = insertSql;
            sqlCommand.ExecuteNonQuery();

            connString.Close();

            return true;

        }
     
        public bool UpdateRental(int year, string make, string model, string color, DateTimeOffset StartDate, DateTimeOffset EndDate, int customerId, int carId)
        {
            string updateSql = "EXEC UpdateRent @Year='" + year + "' @Make='"+make+"',@Model='"+model+"',@Color='"+color+"', @StartDate='" + StartDate + "', @EndDate='" + EndDate + "'";
            connString.Open();
            SqlCommand sqlCommand = connString.CreateCommand();
            sqlCommand.CommandText = updateSql;
            sqlCommand.ExecuteNonQuery();
            connString.Close();

            return true;
        }
       
    }
}