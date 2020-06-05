using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Areas.Api.ViewModels
{
    public class SearchProductViewModel
    {
        public SearchProductViewModel()
        {
            Attributes = new List<ProductAttributes>();
        }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int BrandName { get; set; }
        public int BrandID { get; set; }
        public int ModelID { get; set; }
        public int ModelName { get; set; }
        public ICollection<ProductAttributes>  Attributes { get; set; }


    }
}
