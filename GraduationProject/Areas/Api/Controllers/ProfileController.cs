using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GraduationProject.Repositry;
using GraduationProject.ExtenstionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.ComponentModel.DataAnnotations;
using GraduationProject.Areas.Api.ViewModels;

namespace GraduationProject.Areas.Api.Controllers
{
    [Route("api/[controller]/Edit/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        //private readonly UsersRepository _repo;
        public ProfileController(UserManager<ApplicationUser> userManager
        {
            _userManager = userManager;
        }


        [HttpPost]
        [Route("Email")]
        public async Task<IActionResult> ChangeEmail([FromBody] ProfileEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid && model.Email != null)
                {
                    //ID returns Email, This is a placeholder.
                    string userId = User.GetUserIdToken();
                    var user = await _userManager.FindByIdAsync(userId);
                    var result = await _userManager.SetEmailAsync(user, model.Email);
                
                    if (result.Succeeded)
                        return Ok("Email Updated Successfully.");
                    else
                        return BadRequest("Email Update was Unsuccessful.");
                }

                return BadRequest("Email change was unsuccessful.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("Password")]
        public async Task<IActionResult> ChangePassword([FromBody] ProfileEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid && model.Password != null && model.CurrentPassword != null)
                {
                    //ID returns Email, This is a placeholder.
                    string userId = User.GetUserIdToken();
                    var user = await _userManager.FindByIdAsync(userId);
                    var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);

                    if (result.Succeeded)
                        return Ok("Password Updated Successfully.");
                    else
                        return BadRequest(result.Errors.ToList()[0].Description);
                }

                return BadRequest("Password change was unsuccessful.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("Phone")]
        public async Task<IActionResult> ChangePhone([FromBody] ProfileEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid && model.PhoneNumber != null)
                {
                    //ID returns Email, This is a placeholder.
                    string userId = User.GetUserIdToken();
                    var user = await _userManager.FindByIdAsync(userId);
                    var result = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);

                    if (result.Succeeded)
                        return Ok("Phone Number Updated Successfully.");
                    else
                        return BadRequest("Phone Number Update was Unsuccessful.");
                }

                return BadRequest("Phone Number change was unsuccessful.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("Username")]
        public async Task<IActionResult> ChangeUsername([FromBody] ProfileEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid && model.Username != null)
                {
                    //ID returns Email, This is a placeholder.
                    string userId = User.GetUserIdToken();
                    var user = await _userManager.FindByIdAsync(userId);
                    var result = await _userManager.SetUserNameAsync(user, model.Username);

                    if (result.Succeeded)
                        return Ok("Username Updated Successfully.");
                    else
                        return BadRequest("Username Update was Unsuccessful.");
                }

                return BadRequest("Username change was unsuccessful.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}