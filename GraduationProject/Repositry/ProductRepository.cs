﻿using GraduationProject.Models;
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
    }
}
