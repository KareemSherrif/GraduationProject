using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Repositry
{
    public class UserProductRepository : Repositry<UserProduct,int> , IUserProductRepository
    {
        private readonly ApplicationDbContext context;
        public UserProductRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
