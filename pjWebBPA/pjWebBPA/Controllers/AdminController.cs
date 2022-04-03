using pjWebBPA.contextModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace pjWebBPA.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        contextDBapb db = new contextDBapb();
        public static string GetMD5(string str)
        {
            if (str == null) return "";
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }


        public ActionResult Index()
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            dynamic mymodel = new ExpandoObject();
            mymodel.coutCustomer = db.CustomerUsers.ToList().Count;
            mymodel.coutProduct = db.ProductCourses.ToList().Count;
            mymodel.countBlog = db.Blogs.ToList().Count;
            mymodel.coutCateBlog = db.CategoryBlogs.ToList().Count;
            mymodel.countOrder = db.Orders.ToList().Count;
            mymodel.countCateCourse = db.CategoryCourses.ToList().Count;
            mymodel.countAdmin = db.UserAccounts.ToList().Count;
            mymodel.countTeacher = db.Teachers.ToList().Count;  
            return View(mymodel);
        }


        public ActionResult Login()
        {
            if (Session["login"] != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAccount userAccount)
        {
            var verifyPassword = GetMD5(userAccount.password);
            UserAccount userLogin = db.UserAccounts.FirstOrDefault(user => user.email == userAccount.email && user.password == verifyPassword);
            if (userLogin != null)
            {
                Session["login"] = true;
                Session["isAdmin"] = true;
                Session["userId"] = userLogin.userId.ToString();
                Session["email"] = userLogin.email.ToString();
                if (userLogin.avatar != null)
                {
                    Session["avatar"] = userLogin.avatar.ToString();
                }
                if (userLogin.displayName != null)
                {
                    Session["displayName"] = userLogin.displayName.ToString();
                }
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.error = "Tài khoản hoặc mật khẩu không đúng!";
            }

            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegisterForm(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {

                var checkEmailExist = db.UserAccounts.FirstOrDefault(s => s.email == userAccount.email);

                if (checkEmailExist != null)
                {
                    ViewBag.error = "Email đã được sử dụng";
                }
                else
                {
                    userAccount.password = GetMD5(userAccount.password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.UserAccounts.Add(userAccount);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.success = "Chúc mừng bạn tạo tài khoản thành công";
                }
            }

            return View();
        }

        public ActionResult RegisterForm()
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
            
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }


        public ActionResult CreateCategoryCourse()
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }


        public ActionResult Categories()
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            dynamic mymodel = new ExpandoObject();
            var listCategoriesBlog = db.CategoryBlogs.ToList();
            var listCategoriesCourse = db.CategoryCourses.ToList();
           
            if(listCategoriesCourse != null)
            {
                mymodel.listCategoriesCourse = listCategoriesCourse;
            }
            mymodel.listCategoriesBlog = listCategoriesBlog;
            return View(mymodel);
        }

        public ActionResult UpdateCategoriesBlog(int id)
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login");
            }

            CategoryBlog cateUpdate = db.CategoryBlogs.FirstOrDefault(c => c.Id == id);
            if(cateUpdate == null)
            {
                ViewBag.error = "Not found";
                return RedirectToAction("Categories", "Admin");
            }

            return View(cateUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCategoriesBlog(CategoryBlog cateInput)
        {
            CategoryBlog cateUpdate = db.CategoryBlogs.SingleOrDefault(item => item.Id == cateInput.Id);
            if (cateUpdate == null)
            {
                ViewBag.error = "Update lỗi";
                return View();
            }

            cateUpdate.Title = cateInput.Title;
            cateUpdate.Slug= cateInput.Slug;
            cateUpdate.Content = cateInput.Content;
            cateUpdate.UpdateAt = DateTime.Now;
            cateUpdate.Thumb = cateInput.Thumb;
            
            db.Entry(cateUpdate).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Categories", "Admin");

        }

        public ActionResult UpdateCategoryCourse(int id)
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login");
            }
            CategoryCourse categoryUpdate = db.CategoryCourses.SingleOrDefault(item => item.CategoryCourseId == id);
            if (categoryUpdate == null)
            {
                ViewBag.error = "Not found";
                return RedirectToAction("Categories", "Admin");
            }
            return View(categoryUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCategoryCourse(CategoryCourse cateInput)
        {
            CategoryCourse cateUpdate = db.CategoryCourses.SingleOrDefault(item => item.CategoryCourseId == cateInput.CategoryCourseId);
            if (cateUpdate == null)
            {
                ViewBag.error = "Update lỗi";
                return View();
            }
            cateUpdate.TitleCategoryCourse = cateInput.TitleCategoryCourse;
            cateUpdate.UrlCourse = cateInput.UrlCourse;
            cateUpdate.CategoryCourseName = cateInput.CategoryCourseName;
            cateUpdate.UpdateAt = DateTime.Now;
            cateUpdate.isHot = cateInput.isHot;

            db.Entry(cateUpdate).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Categories", "Admin");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategoryCourse(CategoryCourse cateCourse)
        {
            if (ModelState.IsValid)
            {
                cateCourse.LevelClass = 1;
                cateCourse.CreateAt = DateTime.Now;
                cateCourse.isNew = true;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.CategoryCourses.Add(cateCourse);

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