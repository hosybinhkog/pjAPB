using pjWebBPA.contextModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pjWebBPA.Controllers
{
    public class CategoryCourseController : Controller
    {
        // GET: CategoryCourse
        contextDBapb db = new contextDBapb();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCourse catecourse)
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }


        public ActionResult Details(int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.listProduct = db.ProductCourses.Where(item => item.CategoryCourseId == id).ToList();
            mymodel.courseCate = db.CategoryCourses.FirstOrDefault(item => item.CategoryCourseId == id);
            return View(mymodel);
        }

        public ActionResult MatchCourse(int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.listProduct = db.ProductCourses.Where(item => item.CategoryCourseId == id).ToList();
            mymodel.courseCate = db.CategoryCourses.FirstOrDefault(item => item.CategoryCourseId == id);
            return View(mymodel);
        }

    }
}