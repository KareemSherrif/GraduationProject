using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraduationProject.Areas.Api.ViewModels;
using GraduationProject.ExtenstionMethods;
using GraduationProject.Models;
using GraduationProject.Repositry;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformation : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;

        public UserInformation(IUsersRepository repository,
            IMapper mapper,
            IReviewRepository reviewRepository)
        {
            this._usersRepository = repository;
            this._mapper = mapper;
            this._reviewRepository = reviewRepository;
        }
        [HttpGet]
        [Route("GetUserInfo/{id}")]
        public ActionResult<UserInformation> GetUserInfo(string Id)
        {
            if(Id == null)
            {
                return BadRequest("Unvalid paratmer");
            }
            ApplicationUser user = _usersRepository.GetUserInformation(Id);
            if(user == null)
            {
                return NotFound("The User Is not found");
            }
            UserInformationViewModel model = _mapper.Map<ApplicationUser, UserInformationViewModel>(user);
            model.Rating = _usersRepository.GetAverageRating(Id);
            return Ok(model);
           

        }
        [HttpGet]
        [Route("UserReviews/{id}")]
        public ActionResult<UsersReviews> GetReviews(string Id)
        {
         
            List<UsersReviews> usersReviews = this._reviewRepository.GetReviewsByUser(Id).ToList();
            if (usersReviews == null)
            {
                return NotFound("The Reviews is not found");

            }
            return Ok(usersReviews);

        }
        [HttpGet]
        [Route("UserRating/{id}")]
        public ActionResult GetRating(string Id)
        {
            var average = _usersRepository.GetAverageRating(Id);
            return Ok(average);
        }

    }
}