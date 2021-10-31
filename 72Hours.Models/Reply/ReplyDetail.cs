using _72Hours.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72Hours.Models
{
    public class ReplyDetail
    {
        public int Id { get; set; }

        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }

        public string Text { get; set; }

        public Guid AuthorId { get; set; }
    }
}
