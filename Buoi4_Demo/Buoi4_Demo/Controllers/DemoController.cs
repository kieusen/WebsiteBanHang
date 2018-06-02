using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buoi4_Demo.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            object a = "Hello a";
            return View(a);
        }

        public ActionResult Demo()
        {
            object b = "Hello b";
            return View("Index", b);
        }
    }
}