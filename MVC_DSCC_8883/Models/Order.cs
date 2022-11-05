using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DSCC_8883.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Product ProductDetails { get; set; }
        public int ClientID { get; set; }
        public Client ClientDetails { get; set; }
        public int EmployeeID { get; set; }
        public Employee EmployeeDetails { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
    }
}