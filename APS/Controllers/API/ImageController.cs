using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Dul;

namespace APS.Controllers.API
{
    public class ImageController : ApiController
    {
        Dul.FileUtility fi = new Dul.FileUtility();

        // GET: api/Image
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Image/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Image
        [HttpPost]
        public string Post()
        {
            string fileName = null;
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpPostedFile = HttpContext.Current.Request.Files["UploadImage"];
                if (httpPostedFile != null)
                {

                    fileName = Dul.FileUtility.GetFileNameWithNumbering(HttpContext.Current.Server.MapPath("~/Image"), httpPostedFile.FileName);
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Image"), fileName);
  
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
            return fileName;
        }

        // PUT: api/Image/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Image/5
        public void Delete(int id)
        {
        }
    }
}
