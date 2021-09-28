using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Homework
{
    public class Homework
    {
        public string sNo { get; set; }
        public string heading { get; set; }
        public string description { get; set; }
        public string subject { get; set; }
        public string Class { get; set; }
        public string CreatedOn { get; set; }
        public string Active { get; set; }
        public string CreatedBy { get; set; }
        public string filePath { get; set; }        
    }
}