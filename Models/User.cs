using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTSS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string StreetAddres { get; set; }
        public string ImageLink { get; set; }
        public string Password { get; set; }
    }
}