﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }   
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string BookshelvesNames { get; set; }
    }
}
