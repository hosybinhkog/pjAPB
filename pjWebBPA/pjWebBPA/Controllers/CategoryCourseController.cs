using pjWebBPA.contextModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

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


        public ActionResult Details(int id, int? page)
        {
            int pageNum = (page ?? 1);
            dynamic mymodel = new ExpandoObject();
            var listDesc = db.Descriptions.SingleOrDefault(item => item.CateCourseId == id);
            if(listDesc != null)
            {
                mymodel.listDesc = listDesc.Description.ToString().Split('*');
                mymodel.listDescSub = listDesc.ListDesc.ToString().Split('*');
            }
            else
            {
                mymodel.listDesc = null;
                mymodel.listDescSub = null;
            }
            mymodel.listProduct = db.ProductCourses.Where(item => item.CategoryCourseId == id).ToList().ToPagedList(pageNum, 5);
            mymodel.courseCate = db.CategoryCourses.FirstOrDefault(item => item.CategoryCourseId == id);
            return View(mymodel);
        }

        public ActionResult MatchCourse(int id, int? active)
        {
            int activeVideo = (active ?? 0);
            ViewBag.activeVideo = activeVideo;
            dynamic mymodel = new ExpandoObject();
            mymodel.listProduct = db.ProductCourses.Where(item => item.CategoryCourseId == id).ToList();
            mymodel.courseCate = db.CategoryCourses.FirstOrDefault(item => item.CategoryCourseId == id);
            if(activeVideo != 0)
            {
                ProductCourse productCourse = db.ProductCourses.FirstOrDefault(item => item.ProductId == activeVideo);
                mymodel.ActiveLink = productCourse.UrlVideoYoutube;
                mymodel.ActiveName = productCourse.ProductName;
            }
            else
            {
                ProductCourse productCourse = mymodel.listProduct[0];
                ViewBag.activeVideo = productCourse.ProductId;
                mymodel.ActiveLink = productCourse.UrlVideoYoutube;
                mymodel.ActiveName = productCourse.ProductName;
            }
            return View(mymodel);
        }

    }
}