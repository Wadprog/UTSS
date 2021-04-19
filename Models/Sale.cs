using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTSS.Models
{
    public class Sale
    {
        public int Id { get; set;  }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public int ProductId { get; set; }
        public string  Product { get; set; }
        public double Price { get; set; } 
        public int Amount { get; set; }
        public int SellerId { get; set; }
        public string Seller { get; set; }
        public DateTime Purchase_Date { get; set; }
        
    }
}