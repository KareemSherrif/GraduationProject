using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Repositry
{
    public interface IUserProductRepository : IRepositry<UserProduct, int>
    {
        public IEnumerable<UserProduct> GetUserProductsWithImages();
        public UserProduct GetUserProductDetails(int productId);
        public IEnumerable<UserProduct> GetUserProductByID(string UserID);

    }
}
