using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class User
    {
        public User()
        {
            blogs = new List<Workblog>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IList<Workblog> blogs { get; set; }
    }
}
