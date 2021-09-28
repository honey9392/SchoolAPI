using SchoolAPI.Models.Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.Controllers
{
    public class GalleryController : ApiController
    {
        public IImageGalleryInterface repository = new ImageGalleryRepository();

        [Route("api/Gallery/GetUpdate")]
        [HttpGet]
        public Object GetUpdate(string sno)
        {
            return repository.GetUpdate(sno);
        }
    }
}
