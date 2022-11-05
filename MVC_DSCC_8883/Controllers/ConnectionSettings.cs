using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DSCC_8883.Controllers
{
    public class ConnectionSettings
    {
        //Hosted web API REST Service base url
        // URL For Localhost Testing
        // IF YOU WANT TO TEST IN LOCAL MACHINE PLEASE UNCOMMENT THIS LINE AND CHANGE WITH CORRESPONDING PORT
        //private static string _url = "https://localhost:44322/";

        // URL for deployed API in AWS
        private static string _url = "http://ec2-34-202-231-199.compute-1.amazonaws.com/";

        public static string GetURL
        {
            get { return _url; }
            set { _url = value; }
        }
    }
}