using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using UTSS.Data;
using Newtonsoft.Json;

namespace UTSS.Models
   
{
    public class Product
    {
       
        public int Id { get; set; }
        public string Item { get; set; }
        public int Stock { get; set; }
        public double UnitPrice { get; set; }
        
     }
    }

