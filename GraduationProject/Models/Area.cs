using System.Collections.Generic;

namespace GraduationProject.Models
{
    public class Area
    {
        public int ID { get; set; }
        public string AreaName { get; set; }
        public City City { get; set; }
        public ICollection<ApplicationUser>  ApplicationUsers { get; set; }
    }
}
