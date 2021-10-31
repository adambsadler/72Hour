using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72Hours.Data
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }
        
        //[ForeignKey("Comment")]
        //public virtual int CommentId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
    }
}
