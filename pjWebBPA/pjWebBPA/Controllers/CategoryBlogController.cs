using pjWebBPA.contextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pjWebBPA.Controllers
{
    public class CategoryBlogController : Controller
    {
        // GET: CategoryBlog


        contextDBapb db = new contextDBapb();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryBlog categoryBlog)
        {
            if (ModelState.IsValid)
            {
                categoryBlog.CreatedAt = DateTime.Now;
                categoryBlog.UserAccountId = int.Parse(Session["userId"].ToString());
                db.Configuration.ValidateOnSaveEnabled = false;
                db.CategoryBlogs.Add(categoryBlog);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.success = "Chúc mừng bạn tạo danh mục thành công";
                return RedirectToAction("Categories", "Admin");
            }
            else
            {
                ViewBag.error = "Dữ liệu vào bị sai";
            }

            return View();
        }
    }
}