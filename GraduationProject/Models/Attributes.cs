using System;
using System.Collections.Generic;

namespace GraduationProject.Models
{
    public partial class Attributes
    {
        public Attributes()
        {
            CategoryAttributes = new HashSet<CategoryAttributes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CategoryAttributes> CategoryAttributes { get; set; }
    }
}
