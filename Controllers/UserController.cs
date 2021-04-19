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
    public class UserController : ApiController
    {
        SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=UTSS;Integrated Security=True");
        User StoreUser = new User();
        private static List<User> UserList = new List<User>();

        public IHttpActionResult Get()
        {

            SqlDataAdapter FoundUsers = new SqlDataAdapter("Select * From Users", con);
            DataTable _DataTable = new DataTable();
            FoundUsers.Fill(_DataTable);
            return Ok(_DataTable);

        }

        public IHttpActionResult GetOne(int id)
        {
            SqlDataAdapter FoundUser = new SqlDataAdapter("Select * From Users Where Id='"+Convert.ToString(id)+"'", con);
            DataTable _DataTable = new DataTable();
            FoundUser.Fill(_DataTable);
            return Ok(_DataTable);
        }


        public IHttpActionResult PostOne(User NewUser)
        {

            con.Open();
            string query = "INSERT INTO Users (Names, PhoneNumber, Email)VALUES (" + "'" + NewUser.Names + "','" + NewUser.PhoneNumber + "','" + NewUser.Email + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();


            return Ok(NewUser);
        }

        public IHttpActionResult PutOne(Customer NewCustomer)
        {
            con.Open();
            string query =
                " UPDATE Users SET Names=" + "'" +
                NewCustomer.Names + "',Email='" +
                NewCustomer.Email + "',PhoneNumber='" +
                NewCustomer.PhoneNumber + "' where Email='" +
                NewCustomer.Email + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return Ok(NewCustomer);
        }
    }
}
