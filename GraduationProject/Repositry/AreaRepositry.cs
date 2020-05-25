using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Repositry
{
    public class AreaRepositry:Repositry<Area,int>, IAreaRepositry
    {

        public AreaRepositry(ApplicationDbContext context)
            :base(context)
        {

        }
    }
}
