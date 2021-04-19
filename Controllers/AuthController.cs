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
    public class AuthController : ApiController
    {
        // GET: Auth
        SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=UTSS;Integrated Security=True");
        Auth StoreAuth = new Auth();
     
        public IHttpActionResult Get(Auth userAuth)
        {
            DataTable _DataTable = new DataTable();
            SqlDataAdapter FoundUser = new SqlDataAdapter("Select * From User Where Email='" + userAuth.Email + "'", con);
            //Verify the password match 
            FoundUser.Fill(_DataTable);
            return Ok(_DataTable);

        }

    }
}