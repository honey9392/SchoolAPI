using SchoolAPI.Models.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.Controllers
{
    public class AttendanceController : ApiController
    {
        public IAttendanceInterface repository = new AttendanceRepository();
        // GET api/values
        [HttpGet]
        public Object GetUpdate(string sno)
        {
            return repository.GetUpdate(sno);
        }
    }
}
