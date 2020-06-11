using GraduationProject.Models;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<UserProduct> GetUserProductByID(string UserID)
        {
            return context.UserProduct
                .Include(a=>a.UserProductImages)
                .Where(a => a.UserId == UserID);
        }

        public IEnumerable<UserProduct> GetUserProductsWithImages()
        {
            return context.UserProduct
                .Include(a => a.UserProductImages)
                .ToList();
        }
        public UserProduct GetUserProductDetails(int userProductId)
        {
            return context.UserProduct
                .Include(a => a.UserProductImages)
                .Include(a => a.User)
                .Include(a => a.User.Area)
                .ThenInclude(a => a.City)
                .Include(a => a.Product)
                .ThenInclude(a => a.ProductAttributes)
                .Include(a => a.Product.Model)
                .Include(a => a.Product.Brand)
                .FirstOrDefault(a => a.Id == userProductId);
        }

        public int GetNumberOfSoldItems(string userId)
        {
            return context.Buys.Count(a => a.UserId == userId);
        }
    }
}
