using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    [Table("BlogPosts")]
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [Display(Name = "Body")]
        public string TextBody { get; set; }
        public DateTime PostDate { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}