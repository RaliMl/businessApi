using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Users
{
    public class UserCreateViewModel
    {
        public string Name { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime ModifiedAt { get; set; }
        //public string BookshelvesIds { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
