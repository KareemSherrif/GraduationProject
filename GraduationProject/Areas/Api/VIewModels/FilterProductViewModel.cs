using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Areas.Api.VIewModels
{
    public class FilterProductViewModel
    {
        public List<string> Brand{ get; set; }
        public List<string> Condition{ get; set; }
        public int  FromPrice{ get; set; }
        public int ToPrice{ get; set; }
        public int Rating{ get; set; }
    }
}
