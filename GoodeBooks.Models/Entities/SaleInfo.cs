﻿using GoodeBooks.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Models.Entities
{
    public class SaleInfo : BaseModel
    {
        public string Country { get; set; }
        public string SaleAbility { get; set; }
        public bool IsEbook { get; set; }
    }
}
