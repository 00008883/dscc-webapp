using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_DSCC_8883.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [DisplayName("First Name")]
        public string FName { get; set; }
        [DisplayName("Last Name")]
        public string LName { get; set; }
        [DisplayName("Branch Code")]
        public string BranchCode { get; set; }
        [DisplayName("Branch Info")]
        public Branch BranchInfo { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
    }
}