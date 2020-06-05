using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Areas.Api.ViewModels;
using GraduationProject.Models;
using GraduationProject.Repositry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GraduationProject.ExtenstionMethods;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace GraduationProject.Areas.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUserProductRepository _userProductRepository;
        private readonly IUserProductImagesRepository _userProductImages;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IUserProductRepository userProductRepository
            , IUserProductImagesRepository userProductImages,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _userProductRepository = userProductRepository;
            _userProductImages = userProductImages;
          _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult AddProduct([FromBody]AddProductViewModel model)
        {
            try
            {
                model.UserId = User.GetUserIdToken();
                if (ModelState.IsValid)
                {
                    UserProduct userProduct =  new UserProduct()
                    {
                        Name = model.Name,
                        UserId = model.UserId,
                        ProductId = model.ProductId,
                        Condition = model.Condition,
                        Description = model.Description,
                        Price = model.Price
                    };

                    _userProductRepository.Add(userProduct);

                    foreach (var imageBase64 in model.Images)
                    {
                        UserProductImages Image = new UserProductImages()
                        {
                            Images = imageBase64,
                            UserProductId = model.ProductId
                        };

                        _userProductImages.Add(Image);
                    }

                    _userProductRepository.SaveAll();

                    return Ok("User Product Added Successfully.");
                }
                return BadRequest("Unable to add product.");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetProduct")]
        public IActionResult GetProducts([FromQuery]string name="")
        {
            var model = _mapper.Map<IEnumerable<Product>, IEnumerable<SearchProductViewModel>>(_productRepository.GetProductSearch(name));
            return Ok(model);
        }
    }
}