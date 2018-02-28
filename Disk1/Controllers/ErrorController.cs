using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Disk1.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }

        public ActionResult Unauthorized()
        {
            Response.StatusCode = 401;
            return View();
        }
    }
}