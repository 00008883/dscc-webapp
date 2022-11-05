using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_DSCC_8883.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [DisplayName("Product Code")]
        public string ProductCode { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        [DisplayName("Product Producer")]
        public string ProductProducer { get; set; }
        [DisplayName("Produced Date")]
        public DateTime ProducedDate { get; set; }
        [DisplayName("Supplied Date")]
        public DateTime SuppliedDate { get; set; }
        public double Price { get; set; }
    }
}