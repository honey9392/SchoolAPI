using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Dashboard
{
    public class Dashboard
    {

        #region Properties
        public string sNo { get; set; }
        public string studentName { get; set; }
        public string fatherName { get; set; }
        public string motherName { get; set; }
        public string classCurrent { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string homePhone { get; set; }
        public string fatherPhone { get; set; }
        public string dob { get; set; }
        public string totalFee { get; set; }
        public string feePaid { get; set; }
        public string attendance { get; set; }
        public string totalDays { get; set; }
        public string lastResult { get; set; }
        public string profileImage { get; set; }
        public string absent { get; set;}
        public string holiday { get;set; }
        #endregion

    }
}