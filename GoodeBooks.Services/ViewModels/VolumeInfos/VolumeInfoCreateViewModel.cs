﻿using GoodeBooks.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.VolumeInfos
{
    public class VolumeInfoCreateViewModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public ICollection<string> AuthorIds { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
    }
}
