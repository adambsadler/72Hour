using _72Hours.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72Hours.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }

        public string Text { get; set; }

        public Guid AuthorId { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        [ForeignKey("Post")]
        public virtual int PostId { get; set; }
        public int ReplyCount { get; set; }
    }
}
