using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pjWebBPA.Controllers
{
    public class LearningPathController : Controller
    {
        // GET: LearningPath
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Fontend()
        {
            return View();
        }


        public ActionResult Backend()
        {
            return View();
        }
    }
}