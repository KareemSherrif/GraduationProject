using GraduationProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Repositry
{
    public class ProductRepository : Repositry<Product, int>, IProductRepository
    {
        private readonly ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }
        public IEnumerable<Attributes> GetCategoryAttributes(int CategoryId)
        {
            return context.CategoryAttributes
                .Where(a => a.CategoryId == CategoryId)
                .Include(x => x.CategoryAttribute)
                .Select(a => a.CategoryAttribute).ToList();
        }

        public IEnumerable<Model> GetModelWithCategories(int CategoryId)
        {
            return context.Model.Where(a => a.CategoryId == CategoryId).ToList();
        }

    }
}
