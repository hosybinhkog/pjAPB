using pjWebBPA.contextModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pjWebBPA.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        contextDBapb db = new contextDBapb();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.success = "Chúc mừng bạn tạo thành công";
            }
            else
            {
                ViewBag.error = "Error";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.teacherDetails = db.Teachers.SingleOrDefault(item => item.TeacherId == id);
            mymodel.teacherList = db.Teachers.ToList();
            return View(mymodel);
        }
    }
}