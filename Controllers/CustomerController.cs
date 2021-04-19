using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using UTSS.Models;
using System.Data.SqlClient;
using System.Data;


namespace UTSS.Controllers
{
    public class CustomerController : ApiController
    {
        SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=UTSS;Integrated Security=True");
        Customer StoreCustomers = new Customer();
       
        public IHttpActionResult Get()
        {

            SqlDataAdapter RetrievedCustomer = new SqlDataAdapter("Select * From Customers", con);
            DataTable _DataTable = new DataTable();
            RetrievedCustomer.Fill(_DataTable);
            return Ok(_DataTable);

        }

       

        public IHttpActionResult PostOne(Customer NewCustomer)
        {

            con.Open();
            string query = "INSERT INTO Customers (Names, PhoneNumber, Email)VALUES (" + "'" + NewCustomer.Names + "','" + NewCustomer.PhoneNumber + "','" + NewCustomer.Email + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();


            return Ok(NewCustomer);
        }

        public IHttpActionResult PutOne(Customer NewCustomer)
        {
            con.Open();
            string query =
                " UPDATE Customers SET Names=" + "'" +
                NewCustomer.Names + "',Email='" +
                NewCustomer.Email + "',PhoneNumber='" +
                NewCustomer.PhoneNumber + "' where Id='" +
                NewCustomer.Id+"'";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return Ok(NewCustomer);
        }
    }
}