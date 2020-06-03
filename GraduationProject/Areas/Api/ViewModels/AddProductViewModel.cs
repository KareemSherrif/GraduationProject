using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Areas.Api.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        [Required,Range(0,1000000)]
        public decimal Price { get; set; }
        [Required, Range(0, 2)]
        public int Condition { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public ICollection<string> Images { get; set; }
    }
}
