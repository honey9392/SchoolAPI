using SchoolAPI.Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.Controllers
{
    public class DashboardController : ApiController
    {
        public IDashboardInterface repository = new DashboardRepository();
        // GET api/values
        [HttpGet]
        public Object GetUpdate(string sno)
        {
            return repository.GetUpdate(sno);
        }
    }
}
