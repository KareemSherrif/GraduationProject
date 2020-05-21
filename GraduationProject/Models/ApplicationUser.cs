using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
        {
            Buys = new HashSet<Buys>();
            Chats = new HashSet<Chats>();
            Suggestions = new HashSet<Suggestions>();
            UserProduct = new HashSet<UserProduct>();
        }

     
        public string Name { get; set; }


        public virtual UsersRatings UsersRatings { get; set; }
        public virtual UsersReviews UsersReviews { get; set; }
        public virtual ICollection<Buys> Buys { get; set; }
        public virtual ICollection<Chats> Chats { get; set; }
        public virtual ICollection<Suggestions> Suggestions { get; set; }
        public virtual ICollection<UserProduct> UserProduct { get; set; }
    }

}
