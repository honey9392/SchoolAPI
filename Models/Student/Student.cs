using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Student
{
    public class Student
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
        public string isStudying { get; set; }
        public string session { get; set; }
        public string profileImage { get; set; }
        #endregion
    }

    public class User
    {
        #region Properties
        public string sNo { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string newPassword { get; set; }
        public string token { get; set; }
        #endregion
    }
}