using _72Hours.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72Hours.Models
{
    public class CommentListItem
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int ReplyCount { get; set; }
        public int PostId { get; set; }

    }
}
