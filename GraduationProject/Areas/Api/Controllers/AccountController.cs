using GraduationProject.Areas.Api.VIewModels;
using GraduationProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GraduationProject.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new ApplicationUser()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Address = model.Address,
                        UserName = model.UserName,
                        PhoneNumber = model.Phonenumber,
                        AreaID = model.AreaID

                    };

                var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                    await _userManager.AddToRoleAsync(user, "User");
                    return Ok(result);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }




            return BadRequest("Unable to register with the entered credentials.");


        }
    }
}