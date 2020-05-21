using System;
using System.Collections.Generic;

namespace GraduationProject.Models
{
    public partial class ProductAttributes
    {
        public string AttributeName { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
