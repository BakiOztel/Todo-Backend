using App.Application.Dtos.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Dtos.blog
{
    public class BlogResponse
    {
        public int Id { get; set; }
        public string text { get; set; }
        public TodoResponse Todo { get; set; }

    }
}
