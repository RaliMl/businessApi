using GoodeBooks.Models.BaseModels;
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
        public VolumeInfo VolumeInfo { get; set; }
        public SaleInfo SaleInfo { get; set; }
        public SearchInfo SearchInfo { get; set; }

    }
}
