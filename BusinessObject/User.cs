using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set;}
        public virtual ICollection<Order> Orders { get; set;}
        public virtual ICollection<UserDetail> UserDetails { get; set;}
        public virtual ICollection<UserRole> UserRoles { get; set;}
    }
}
