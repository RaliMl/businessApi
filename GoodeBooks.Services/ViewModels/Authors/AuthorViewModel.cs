using GoodeBooks.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Authors
{
    public class AuthorViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string VolumeInfoTitles { get; set; }
    }
}
