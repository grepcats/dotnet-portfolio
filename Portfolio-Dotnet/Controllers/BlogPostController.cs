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
using System.Security.Claims;

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
        public async Task<IActionResult> Create(BlogPost blogPost)
        {
            blogPost.PostDate = DateTime.Now;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            blogPost.User = await _userManager.FindByIdAsync(userId);
            _db.BlogPosts.Add(blogPost);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisBlogPost = _db.BlogPosts.Include(blogPosts => blogPosts.User).SingleOrDefault(q => q.BlogPostId == id);
            Comment comment = new Comment
            {
                BlogPost = thisBlogPost,
                BlogPostId = id
            };
            thisBlogPost.Comments = _db.Comments
                .Where(Comments => Comments.BlogPostId == id)
                .OrderByDescending(x => x.PostDate)
                .Include(u => u.User)
                .ToList();
            ViewBag.Comments = _db.Comments.Where(a => a.BlogPostId == id).ToList();

            return View(comment);
        }


        public IActionResult Update(int id)
        {
            var thisPost = _db.BlogPosts.FirstOrDefault(BlogPosts => BlogPosts.BlogPostId == id);
            return PartialView(thisPost);
        }

        [HttpPost]
        public IActionResult Update(BlogPost blogPost)
        {
            _db.Entry(blogPost).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details", "BlogPost", new { id = blogPost.BlogPostId });
        }

        public IActionResult Delete(int id)
        {
            var blogPost = _db.BlogPosts.FirstOrDefault(BlogPosts => BlogPosts.BlogPostId == id);
            return PartialView(blogPost);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(BlogPost blogPost)
        {
            _db.Remove(blogPost);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ListPosts()
        {
            List<BlogPost> model = _db.BlogPosts.OrderByDescending(x => x.PostDate).ToList();
            return PartialView(model);
        }
        
    }
}
