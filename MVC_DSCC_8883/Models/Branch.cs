using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_DSCC_8883.Models
{
    public class Branch
    {
        [Key]
        [DisplayName("Branch Code")]
        public string BranchCode { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        [DisplayName("Post Code")]
        public string PostCode { get; set; }
    }
}