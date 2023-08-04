using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Dtos.blog
{
    public class CreateBlogReguest
    {
        [Required]
        public string text { get; set; }
        [Required]
        public int UserId { get; set; }

        public string TodoText { get; set; }

    }
}
