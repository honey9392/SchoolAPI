using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models
{
    public class Events
    {
        public string Id { get; set; }
        public string session { get; set; }
        public string toDate { get; set; }
        public string fromDate { get; set; }
        public string eventName { get; set; }
        public string remark { get; set; }
    }
}