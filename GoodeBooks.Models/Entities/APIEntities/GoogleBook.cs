using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Models.Entities.APIEntities
{
    public class GoogleBook
    {
        public string Kind { get; set; }
        public string Etag { get; set; }
        public virtual GoogleVolumeInfo VolumeInfo { get; set; }
        public virtual SaleInfo SaleInfo { get; set; }
        public virtual SearchInfo SearchInfo { get; set; }
    }
}
