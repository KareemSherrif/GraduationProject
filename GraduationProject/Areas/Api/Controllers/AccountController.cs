using GraduationProject.Areas.Api.VIewModels;
using GraduationProject.Models;
using GraduationProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GraduationProject.Areas.Api.ViewModels;
using GraduationProject.ExtenstionMethods;
using GraduationProject.Repositry;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace GraduationProject.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configration;
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;
        private readonly IReviewRepository _reviewRepository;

        public AccountController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, IConfiguration configration,
            IUsersRepository usersRepository, 
            IMapper mapper,
            IReviewRepository reviewRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configration = configration;
            this.usersRepository = usersRepository;
            this.mapper = mapper;
            this._reviewRepository = reviewRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Name = "Account" });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Find login user by userName
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    //if user found Check the password 
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result.Succeeded)
                    {
                        //create token
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Id),
                            new Claim(JwtRegisteredClaimNames.Acr, user.Id),
                             new Claim(JwtRegisteredClaimNames.Actort, user.Id)
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configration["Tokens:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(null, null,
                            claims, expires: DateTime.Now.AddMinutes(60),
                            signingCredentials: credentials);

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            userId = user.Id,
                            userName = user.UserName
                        });
                    }
                }
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationViewModel model)
        {
            //If the user-entered data is validated, Create the user in the database.
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
                    //If the user is successfully created, asign them to the role of "User"
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

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);
                    // email is sent
                    string subject = "Welcome to App-Name! Confirm Your Email";
                    string message = "You're on your way! Let's confirm your email address. By clicking on the following link, you are confirming your email address" + passwordResetLink;
                    AuthMessageSenderOptions options = new AuthMessageSenderOptions();
                    EmailSender emailSender = new EmailSender((IOptions<AuthMessageSenderOptions>)options);
                    await emailSender.SendEmailAsync(model.Email, subject, message);
                    //Logger.Log(LogLevel.Warning, passwordResetLink);
                    return Ok();
                }
                return BadRequest("Please ReEnter your Email");
            }
            return BadRequest("Invalid Email");
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            if (token == null && email == null)
            {
                ModelState.AddModelError("", "Invalid Password reset token");
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RresetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return BadRequest("check the data you entered");
                }
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("UserInfo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<UserInformationViewModel> GetUserInformation()
        {
            string userId = User.GetUserIdToken();
            ApplicationUser applicationUser = usersRepository.GetUserInformation(userId);

            if (applicationUser == null)
            {
                return NotFound("This user is not found");
            }
            UserInformationViewModel model = mapper.Map<ApplicationUser, UserInformationViewModel>(applicationUser);
            return Ok(model);

        }
        [HttpGet]
        [Route("UserReviews")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<UsersReviews> GetReviews()
        {
            string userId = User.GetUserIdToken();
            List<UsersReviews> usersReviews = this._reviewRepository.GetReviewsByUser(userId).ToList();
            if (usersReviews == null)
            {
                return NotFound("The Reviews is not found");

            }
            return Ok(usersReviews);

        }


    }
}
