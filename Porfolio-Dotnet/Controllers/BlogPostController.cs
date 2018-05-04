using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Portfolio.Controllers
{
   
    public class BlogPostController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BlogPostController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(BlogPost blogPost)
        {
            blogPost.PostDate = DateTime.Now;
            _db.BlogPosts.Add(blogPost);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public IActionResult ListPosts()
        //{
        //    var model = _db.BlogPosts.ToList();
        //    return Json(model);
        //}

        //public IActionResult DisplayComments()
        //{
        //    return View();
        //}

        //public IActionResult CommentForm()
        //{
        //    return View();
        //}

        public IActionResult Details(int id)
        {
            //var thisBlogPost = _db.BlogPosts.FirstOrDefault(BlogPosts => BlogPosts.BlogPostId == id);

            var thisBlogPost = _db.BlogPosts.Include(blogPosts => blogPosts.User).SingleOrDefault(q => q.BlogPostId == id);
            Comment comment = new Comment();
            comment.BlogPost = thisBlogPost;
            comment.BlogPostId = id;
            ViewBag.Comments = _db.Comments.Where(a => a.BlogPostId == id);
            return View(comment);
            //thisBlogPost.Comments = thisBlogPost.Comments.Where(Comments => Comments.BlogPostId == id).ToList();


            return View(thisBlogPost);
        }

        public IActionResult ListPosts()
        {
            List<BlogPost> model = _db.BlogPosts.ToList();
            return View(model);
        }
        
    }
}
