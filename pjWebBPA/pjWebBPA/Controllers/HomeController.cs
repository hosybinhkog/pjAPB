using pjWebBPA.contextModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pjWebBPA.Controllers
{
    public class HomeController : Controller
    {

        contextDBapb db = new contextDBapb();
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            var listCourseNotFontend = db.CategoryCourses.Where(item => item.isFondend == false).ToList();
            var listCourseFondend = db.CategoryCourses.Where(item => item.isFondend == true).ToList();  
            var blogHot = db.Blogs.Where(item => item.isNewfeed == true).ToList();
            var listCategoryBLog = db.CategoryBlogs.ToList();

            mymodel.listCourseNotFontend = listCourseNotFontend;
            mymodel.listCourseFondend = listCourseFondend;
            mymodel.blogHot = blogHot;
            mymodel.listCategoryBLog = listCategoryBLog;
            mymodel.listTeacher = db.Teachers.ToList();
            return View(mymodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}