using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.StarRate
{
    public class StarRateCreateViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string VolumeTitle { get; set; }
        public int Rate { get; set; }
    }
}
