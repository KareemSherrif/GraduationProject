using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Repositry
{
    public class CategoryRepositry:Repositry<Category,int>,ICategoryRepositry
    {
        public CategoryRepositry(ApplicationDbContext context)
            :base(context)
        {

        }
    }
}
