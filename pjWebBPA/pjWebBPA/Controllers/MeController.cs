using pjWebBPA.contextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pjWebBPA.Controllers
{
    public class MeController : Controller
    {
        // GET: Me
        contextDBapb db = new contextDBapb();
        public ActionResult Index()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            int id = int.Parse(Session["userId"].ToString());
            CustomerUser user = db.CustomerUsers.SingleOrDefault(item => item.CustomerId == id);
            return View(user);
        }

        public ActionResult BlogOfMe()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            int id = int.Parse(Session["userId"].ToString());
            return View();
        }

        public ActionResult Update()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            int id = int.Parse(Session["userId"].ToString());
            CustomerUser user = db.CustomerUsers.SingleOrDefault(item => item.CustomerId == id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CustomerUser user)
        {
            int id = int.Parse(Session["userId"].ToString());
            var existEmail = db.CustomerUsers.SingleOrDefault(item => item.CustomerId == id);
            existEmail.Blogs = db.Blogs.Where(item => item.AccountId == id).ToList();
            if (existEmail.Email == user.Email)
            {
                existEmail.DisplayName = user.DisplayName;
                existEmail.Code = user.Code;
                existEmail.Address = user.Address;
                existEmail.Country = user.Country;
                existEmail.District = user.District;    
                db.Entry(existEmail).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                var checkEmail = db.CustomerUsers.SingleOrDefault(item => item.Email == user.Email);
                if(checkEmail == null)
                {
                    existEmail.DisplayName = user.DisplayName;
                    existEmail.Code = user.Code;
                    existEmail.Address = user.Address;
                    existEmail.Country = user.Country;
                    existEmail.District = user.District;
                    existEmail.Email = user.Email;
                    db.Entry(existEmail).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại";
                    return View();
                }
            }
            
           

            return Redirect("Index");
        }
    }
}