using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Users
{
    public class UserCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{6,}$", 
            ErrorMessage = "The password must be at least 6 characters long and contain at least one lowercase letter," +
            " one uppercase letter, one digit, and one special character.")]
        public string Password { get; set; }
    }
}
