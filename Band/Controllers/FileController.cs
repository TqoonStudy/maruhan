using Band.Service;
using Models.File.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Band.Controllers
{
    public class FileController : Controller
    {
        FileService service = new FileService();
        // GET: Image
        public string GetImg(int id)
        {
            string result = service.GetImg(id);
            return result;
        }

        public JsonResult GetAllBandImg()
        {
            List<string> result = service.GetAllBandImg();

            return Json(result);
        }
    }
}