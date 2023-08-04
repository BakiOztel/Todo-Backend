using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Workblog
    {
        public int Id { get; set; }
        public int TodoId { get; set; }
        public int UserId { get; set; }
        public string text { get; set; }
        public Todo Todo { get; set; }
        public User User { get; set; }
    }
}
