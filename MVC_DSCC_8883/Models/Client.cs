using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DSCC_8883.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public int? LoyaltyLevel { get; set; }
        public Loyalty LoyaltyInfo { get; set; }
        public string PostCode { get; set; }
    }
}