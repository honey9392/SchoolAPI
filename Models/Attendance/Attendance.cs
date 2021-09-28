using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Attendance
{
    public class Attendance
    {
        #region Properties
        public string sNo { get; set; }
        public string classCurrent { get; set; }
        public int Id { get; set; }
        public string date { get; set; }
        public string attendanceMark { get; set; }
        public string color { get; set; }
        public string staffType { get; set; }
        #endregion
    }
}