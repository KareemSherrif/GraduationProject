using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Repositry;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository product;

        public ProductsController(IProductRepository product)
        {
            this.product = product;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
