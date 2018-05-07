using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

   
        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            //TODO- add user to comment.User
            
            comment.PostDate = DateTime.Now;
            comment.UserId = (this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = _db.Comments.Select(comments => comments.User).SingleOrDefault(q => q.Id == comment.UserId);
            comment.User = user;

            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
            return RedirectToAction("Details", "BlogPost", new { id = comment.BlogPostId });
            //return RedirectToAction("Index", "Home");
        }

    }
}
