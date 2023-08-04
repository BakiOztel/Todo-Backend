using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Dtos.Todo
{
    public class TodoResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool isDone { get; set; }
    }
}
