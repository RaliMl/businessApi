﻿using GoodeBooks.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Models.Entities
{
    public class Volume : BaseModel
    {
        public string Kind { get; set; }
        public string Etag { get; set; }
        public virtual VolumeInfo VolumeInfo { get; set; }
        public virtual SaleInfo SaleInfo { get; set; }
        public virtual SearchInfo SearchInfo { get; set; }
        public virtual ICollection<Bookshelf>? Bookshelves { get; set; }
        public double AverageRate { get; set; } = 0;

    }
}
