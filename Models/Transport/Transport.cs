using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Transport
{
    public class Transport
    {
        #region Properties
        public int vehID { get; set; }
        public string sNo { get; set; }
        public string regNo { get; set; }
        public string vehType { get; set; }
        public string driverName { get; set; }
        public string phoneNo { get; set; }
        public string alternativeNo { get; set; }
        public string routeSum { get; set; }
        #endregion
    }
}