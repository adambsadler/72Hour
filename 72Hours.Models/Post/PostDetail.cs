using _72Hours.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72Hours.Models.Post
{
    public class PostDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int CommentCount { get; set; }
    }
}
