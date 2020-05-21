using System;
using System.Collections.Generic;

namespace GraduationProject.Models
{
    public partial class UsersReviews
    {
        public string Review { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
