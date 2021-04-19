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
    public class ProductController : ApiController
    {
        SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=UTSS;Integrated Security=True");
        
        public IHttpActionResult Get()
        {

            SqlDataAdapter RetrievedProducts = new SqlDataAdapter("Select * From Product", con);
            DataTable  _DataTable = new DataTable();
            RetrievedProducts.Fill(_DataTable);
            return Ok(_DataTable);
        }

        public IHttpActionResult PostOne(Product NewProduct)
        {

            con.Open(); 
            string query = "INSERT INTO Product (Item, Stock, UnitPrice)VALUES ("+"'"+ NewProduct.Item+"',"+ NewProduct.Stock+","+ NewProduct.UnitPrice+")"; 
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

          
            return Ok(NewProduct);
        }

        public IHttpActionResult PutOne(Product NewProduct)
        {
            con.Open();
            string query =
                " UPDATE Product SET Item=" + "'" +
                NewProduct.Item + "',Stock=" +
                NewProduct.Stock + ",UnitPrice=" +
                NewProduct.Stock + "where Id=" +
                NewProduct.Id;

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return Ok(NewProduct);
        }
    }
}
