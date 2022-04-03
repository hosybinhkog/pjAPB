using pjWebBPA.contextModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pjWebBPA.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        contextDBapb db = new contextDBapb();
        public ActionResult Index()
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login","Admin");
            }
            var data = db.ProductCourses.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ProductCourse obj = new ProductCourse();
            obj.listCategoriesCourse = db.CategoryCourses.ToList();
            obj.listTeacher = db.Teachers.ToList();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCourse product)
        {
            if (ModelState.IsValid)
            {
                product.isNew = true;
                product.CreateAt = DateTime.Now;
                product.AuthorId = 1;
                
                db.Configuration.ValidateOnSaveEnabled = false;
                db.ProductCourses.Add(product);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.success = "Chúc mừng bạn tạo  thành công";
            }
            else
            {
                ViewBag.error = "Error";
            }
            return View();
        }

        public ActionResult details(int id)
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }


            return View();
        }
    }
}