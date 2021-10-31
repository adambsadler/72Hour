using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72Hours.Models.Post
{
    public class PostCreate
    {
        [Required, Display(Name = "Your post")]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
