using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GraduationProject.Repositry;
using GraduationProject.Models;
using GraduationProject.Areas.Api.VIewModels;
using Microsoft.EntityFrameworkCore.Storage;

namespace GraduationProject.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepositry _CategoryRepository;
        private readonly IFIlterRepository _FIlterRepository;

        public CategoriesController(ICategoryRepositry categoryRepositry, IFIlterRepository fIlterRepository)
        {
            _CategoryRepository = categoryRepositry;
            _FIlterRepository = fIlterRepository;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var AllCategories = _CategoryRepository.GetAll();
            return Ok(AllCategories);
        }

        [HttpGet]
        [Route("GetCategory/{id}")]
        public IActionResult GetCategory(int id)
        {
            //int i = int.Parse(id);
            Category category = _CategoryRepository.Get(id);
            List<Dictionary<string, Object>> filters = _FIlterRepository.GetFilterByCategory(id);
           // List<string> titleNames= _FIlterRepository.GetFilterByCategory(id);
            //List<string> StaticChoices= _FIlterRepository.GetStaticChoices(id);
            //List<string> dynamicChoices= _FIlterRepository.GetDynamicChoices(id);
            return Ok(filters);
        }

        [HttpGet]
        [Route("GetFilterProducts")]
        public IActionResult GetFilterProducts([FromQuery] FilterProductViewModel filterProductViewModel)
        {
            string method = " select p.* from UserProduct p ";
            if (filterProductViewModel.Brand != null)
            {
                method = method + " inner join Product g " +
                                  " on p.ProductId = g.Id " +
                                  " inner join dbo.Brand b " +
                                  " on b.Id = g.BrandId and";
                for (int i = 1; i <=  filterProductViewModel.Brand.Count(); i++)
                {
                    method = method + " b.Name='" + filterProductViewModel.Brand[i-1] + "' ";
                    if (filterProductViewModel.Brand.Count() > 1 && i != filterProductViewModel.Brand.Count())
                    {
                        method = method + " or ";
                    }
                }
            }
            if (filterProductViewModel.Rating != 0)
            {
                method = method + "inner join Users_Ratings r " +
                                  " on r.UserId = p.UserId " +
                                  " and r.Rating >= " + filterProductViewModel.Rating;
            }
            if (filterProductViewModel.Condition != null || filterProductViewModel.FromPrice != 0 || filterProductViewModel.ToPrice != 0)
            {
                //method = method + " where ";
                if (filterProductViewModel.Condition != null)
                {
                    method = method + " where p.condition =";
                    for (int i = 1; i <= filterProductViewModel.Condition.Count(); i++)
                    {
                        if (filterProductViewModel.Condition[i-1] == "New")
                        {
                            method = method + " 0 ";
                        }
                        if (filterProductViewModel.Condition[i-1] == "Used with Box")
                        {
                            method = method + " 1 ";
                        }
                        if (filterProductViewModel.Condition[i-1] == "Used without Box")
                        {
                            method = method + " 2 ";
                        }
                        if (filterProductViewModel.Condition.Count() > 1 && i != filterProductViewModel.Condition.Count())
                        {
                            method = method + " and ";
                        }
                    }
                }
                if (filterProductViewModel.FromPrice != 0)
                {
                    method = method + " and ";
                    method = method + "p.price >" + filterProductViewModel.FromPrice;
                }
                else
                {
                    method = method + " and ";

                    method = method + "p.price > 0";
                }
                if (filterProductViewModel.ToPrice != 0)
                {
                    method = method + " and p.price <" + filterProductViewModel.ToPrice;
                }
            }
 
            List<UserProduct> products = _FIlterRepository.GetFilterdProducts(method);

            return Ok(products);
        }
    }
}