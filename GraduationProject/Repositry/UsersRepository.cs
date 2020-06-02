using GraduationProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Repositry
{
    public class UsersRepository : Repositry<ApplicationUser, string> , IUsersRepository
    {
        private readonly ApplicationDbContext context;

        public UsersRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public ApplicationUser GetUserInformation(string UserId)
        {
            return context.Users.Include(a => a.Area)
                   .ThenInclude(a => a.City).FirstOrDefault(a => a.Id == UserId);
                
        }
    }
}
