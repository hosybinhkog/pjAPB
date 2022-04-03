using pjWebBPA.contextModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pjWebBPA.Controllers
{
    public class CustomerAdminController : Controller
    {
        // GET: CustomerAdmin
        contextDBapb db = new contextDBapb();
        public ActionResult Index()
        {
            if (Session["login"] == null || Session["isAdmin"] == null)
            {
                return RedirectToAction("Login","Admin");
            }
            dynamic mymodel = new ExpandoObject();
            var listCustomer = db.CustomerUsers.ToList();
            mymodel.listCustomer = listCustomer;
            mymodel.listAdmin = db.UserAccounts.ToList();
            mymodel.listTeacher = db.Teachers.ToList();
            return View(mymodel);
        }
    }
}