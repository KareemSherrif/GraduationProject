using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Areas.Api.ViewModels
{
    public class ProfileEditViewModel
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }
        
        public string Password { get; set; }
        public string CurrentPassword { get; set; }
        [StringLength(11, MinimumLength = 11)]
        public string PhoneNumber { get; set; }
    }
}
