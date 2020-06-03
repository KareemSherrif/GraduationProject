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

namespace GraduationProject.Areas.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AddProductController : ControllerBase
    {
        private readonly IUserProductRepository _userProductRepository;
        private readonly IUserProductImagesRepository _userProductImages;

        public AddProductController(IUserProductRepository userProductRepository, IUserProductImagesRepository userProductImages)
        {
            _userProductRepository = userProductRepository;
            _userProductImages = userProductImages;
        }

        [HttpPost]
        [Route("Add")]
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
    }
}