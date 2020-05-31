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

namespace GraduationProject.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly UsersRepository _repo;
        public ProfileController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager/*, UsersRepository repo*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_repo = repo;
        }

        [HttpPost]
        [Route("ChangeEmail")]
        
        public async Task<IActionResult> ChangeEmail(string newEmail)
        {
            var userEmail = User.GetUserEmail();
            var user = await _userManager.FindByEmailAsync(userEmail);
            user.Email = newEmail;
            
            return Ok("User Email Updated Successfully !");
        }
    }
}