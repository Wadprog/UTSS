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
    public class SaleController : ApiController
    {
     SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=UTSS;Integrated Security=True");

     public IHttpActionResult Get()
     {

       string queryString = @"Select Sales.Id,CustomerId,Customers.Names AS Customer,
       Item As Product,Sales.UnitPrice As Price,Sales.UnitSold As Amount,UserId AS SellerId,
       Users.FirstName As Seller,Sales.DateMade As Purchase_Date From Sales
       Join Product on ProductId = Product.Id
       JOIN Customers on CustomerId = Customers.Id
       JOIN Users on UserId = Users.Id
       ORDER BY Customers.Names";

      SqlDataAdapter OrderRecords = new SqlDataAdapter(queryString, con);
      DataTable _DataTable = new DataTable();
      OrderRecords.Fill(_DataTable);
      return Ok(_DataTable);
     }

            public IHttpActionResult PostOne(Sale SaleOrder)
            {


            string queryStart = " Insert into Sales(UserId, CustomerId, ProductId, UnitPrice, UnitSold, DateMade) Value(";
            string queryEnd = +SaleOrder.SellerId + ',' + SaleOrder.CustomerId + ',' +SaleOrder.ProductId.ToString() + ',' + SaleOrder.Price + ',' + SaleOrder.Amount + ",'" +"'2020/11/11'" +')';
            string query = queryStart + queryEnd; 
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return Ok(SaleOrder);
            }

            public IHttpActionResult PutOne(Sale Order)
            {
                con.Open();
                string query =
                    " UPDATE Sales SET UserId=" + "'" +
                    Order.SellerId + "',CustomerId=" +
                    Order.CustomerId + ",UnitPrice=" +
                    Order.Price + ",UnitSold=" +
                    Order.Amount + ",DateMade=" +
                    Order.Purchase_Date + ",ProductId=" +
                    Order.ProductId + "where Id=" +
                    Order.Id;

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return Ok(Order);
            }
        }
    }



