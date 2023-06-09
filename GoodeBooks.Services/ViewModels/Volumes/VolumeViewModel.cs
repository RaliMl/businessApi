﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Volumes
{
    public class VolumeViewModel
    {
        public string Id { get; set; }
        public string Kind { get; set; }
        public string Etag { get; set; }
        public string VolumeName { get; set; }
        public string Country { get; set; }
        public string TextSnippet { get; set; }
        public string ImageUrl { get; set; }
        public double AverageRate { get; set; }
    }
}
