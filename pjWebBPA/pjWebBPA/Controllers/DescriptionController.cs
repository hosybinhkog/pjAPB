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
    public class DescriptionController : Controller
    {
        // GET: Description
        contextDBapb db = new contextDBapb();
        // dynamic mymodel = new ExpandoObject();
        public ActionResult Index(int? page)
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            int pageNum = (page ?? 1);
            int pageSize = 5;
            dynamic mymodel = new ExpandoObject();
            mymodel.listDescription = db.Descriptions.ToList().ToPagedList(pageNum, pageSize);
            mymodel.listCategoryCourse = db.CategoryCourses.ToList();
            return View(mymodel);
        }

        public ActionResult Create()
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            description newDescription = new description();
            newDescription.listCategoryCourse = db.CategoryCourses.ToList();

            return View(newDescription);
        }

        [HttpPost]
        public ActionResult Create(description obj)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Descriptions.Add(obj);

                db.SaveChanges();
                ModelState.Clear();
                ViewBag.success = "Chúc mừng bạn tạo danh mục thành công";
                return RedirectToAction("Index", "Description");
            }
            else
            {
                ViewBag.error = "Dữ liệu vào bị sai";
            }
            return View();
        }


    }
}