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
                int year = (int)sqlReader["Year"];
                string make = (string)sqlReader["Make"];
                string model = (string)sqlReader["Model"];
                string color = (string)sqlReader["Color"];

                cars.Add(new Car(year, make, model, color));

                
            }
            connString.Close();
            return cars;
            
        }


        ////TBD!!!//
        //public List<Rental> GetRentals()
        //{
        //    List<Rental> rentals = new List<Rental>();
        //    string SelectCommand = "SELECT * FROM Rental;";
        //    connString.ConnectionString = "";
        //    connString.Open();
        //    SqlCommand sqlCommand = connString.CreateCommand();
        //    sqlCommand.CommandText = SelectCommand;
        //    SqlDataReader sqlReader = sqlCommand.ExecuteReader();
        //    while (sqlReader.Read())
        //    {
        //        int year = (int)sqlReader["Year"];
        //        string make = (string)sqlReader["make"];
        //        string model = (string)sqlReader["model"];
        //        string color = (string)sqlReader["Color"];
        //        DateTimeOffset startDate = (DateTimeOffset)sqlReader["StartDate"];
        //        DateTimeOffset endDate = (DateTimeOffset)sqlReader["EndDate"];

        //        rentals.Add(new Rental());


        //    }
        //    connString.Close();
        //    return rental;

        //}
        public bool InsertRental(int year, string make,string model,  DateTimeOffset StartDate, DateTimeOffset EndDate)
        {
            string insertSql = "Insert into Rental(Year,Make,Model,Color,StartDate,EndDate,CustomerId,CarId";
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