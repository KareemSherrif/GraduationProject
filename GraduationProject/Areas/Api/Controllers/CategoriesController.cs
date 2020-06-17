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
using MyDataLayerCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepositry _CategoryRepository;
        private readonly IFIlterRepository _FIlterRepository;
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext context;

        public CategoriesController(ICategoryRepositry categoryRepositry, 
            IFIlterRepository fIlterRepository,
            IConfiguration configuration,
            ApplicationDbContext context)
        {
            _CategoryRepository = categoryRepositry;
            _FIlterRepository = fIlterRepository;
            this.configuration = configuration;
            this.context = context;
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
           


                

            return Ok();
        }

        private void InitialValues(FilterProductViewModel filterProductViewModel)
        {
            if(filterProductViewModel.Brand.Count == 0)
            {
                
                foreach (var item in this.context.Brand.ToList())
                {
                    filterProductViewModel.Brand.Add(item.Name);
                }
  
            }

            if(filterProductViewModel.Condition.Count == 0)
            {
                filterProductViewModel.Condition.Add("0");
                filterProductViewModel.Condition.Add("1");
                filterProductViewModel.Condition.Add("2");
            }
            if(filterProductViewModel.ToPrice == 0)
            {
                filterProductViewModel.ToPrice = 999999999;
            }
        }
    }
}