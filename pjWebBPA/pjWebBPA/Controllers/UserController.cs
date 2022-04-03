using pjWebBPA.contextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace pjWebBPA.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        contextDBapb db = new contextDBapb();

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Login()
        {
            if (Session["login"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomerUser userAccount)
        {
            var verifyPassword = GetMD5(userAccount.password);
            CustomerUser userLogin = db.CustomerUsers.FirstOrDefault(user => user.Email == userAccount.Email && user.password == verifyPassword);
            if(userLogin != null)
            {
                Session["login"] = true;
                Session["userId"] = userLogin.CustomerId.ToString();
                Session["email"] = userLogin.Email.ToString();
                if(userLogin.DisplayImage != null)
                {
                    Session["avatar"] = userLogin.DisplayImage.ToString();
                }
                if (userLogin.DisplayName != null)
                {
                    Session["displayName"] = userLogin.DisplayName.ToString();
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Tài khoản hoặc mật khẩu không đúng!";
            }

            return View();
        }


        public ActionResult Register()
        {
            if (Session["login"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegisterForm(CustomerUser userAccount)
        {
            if (ModelState.IsValid)
            {

                var checkEmailExist = db.CustomerUsers.FirstOrDefault(s => s.Email == userAccount.Email);

               if(checkEmailExist != null)
                {
                    ViewBag.error = "Email đã được sử dụng";    
                }
                else
                {
                    userAccount.password = GetMD5(userAccount.password);
                    userAccount.CreateAt = DateTime.Now;    
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.CustomerUsers.Add(userAccount);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.success = "Chúc mừng bạn tạo tài khoản thành công";
                }
            }

            return View();
        }

        public ActionResult RegisterForm()
        {
            return View();
        }

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

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }


        public ActionResult Test()
        {
            ViewBag.message = "Chúc mừng bạn tạo tài khoản thành công";
            return(ViewBag);
        }
    }
}