using pjWebBPA.contextModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pjWebBPA.Controllers
{
    
    public class BlogController : Controller
    {
        // GET: Blog

        contextDBapb db = new contextDBapb();

        public ActionResult Index()
        {
            var listBlog = db.Blogs.ToList();
            var listCategory = db.CategoryBlogs.ToList();
            dynamic mymodel = new ExpandoObject();
            mymodel.listBlog = listBlog;
            mymodel.listCategory = listCategory;    
            return View(mymodel);
        }

        public ActionResult BlogByCate(int id)
        {
            var listBlog = db.Blogs.Where(blog => blog.CategoryBlogId == id);
            var listCategory = db.CategoryBlogs.ToList();
            dynamic mymodel = new ExpandoObject();
            mymodel.listBlog = listBlog;
            mymodel.listCategory = listCategory;
            return View(mymodel);
        }

        public ActionResult Create()
        {
            if (Session["userId"] == null) return RedirectToAction("Login", "User");
            Blog blog = new Blog();
            blog.listCategories = db.CategoryBlogs.ToList();
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {

                if(Session["displayName"] != null)
                {
                    blog.Author = Session["displayName"].ToString();
                }
                else
                {
                    blog.Author = Session["email"].ToString();
                }
                if(Session["avatar"] != null)
                {
                    blog.imageAuthor = Session["avatar"].ToString();
                }
                else
                {
                    blog.imageAuthor = "https://openclipart.org/image/800px/247320";
                }
                blog.AccountId = int.Parse(Session["userId"].ToString());
                blog.isNewfeed = true;
                blog.isHot = false;
                blog.CreateAt = DateTime.Now;
                blog.CategoryBlogId = 4;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Blogs.Add(blog);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.success = "Chúc mừng bạn tạo bài viết thành công";
            }
            else
            {
                ViewBag.error = "Error";
            }
            return View();
        }


        public ActionResult Destails(int id)
        {
            Blog blog = db.Blogs.SingleOrDefault(item => item.BlogId == id);
            var listBlog = db.Blogs.Where(item => item.isHot == true).ToList();
            var listCategory = db.CategoryBlogs.ToList();
            var authorBlog = db.Blogs.Where(item => item.AccountId == blog.AccountId).ToList();
            dynamic mymodel = new ExpandoObject();
            mymodel.blogDetails = blog;
            mymodel.listBlog = listBlog;
            mymodel.listCategory = listCategory;
            mymodel.authorBlog = authorBlog;
            if (blog == null)
            {
                return RedirectToAction("Index");
            }
            return View(mymodel);
        }
    }
}