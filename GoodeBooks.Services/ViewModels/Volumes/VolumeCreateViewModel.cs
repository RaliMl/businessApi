using GoodeBooks.Models.BaseModels;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ModelContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Volumes
{
    public class VolumeCreateViewModel : IVolumeViewModel
    {
        public string Kind { get; set; }
        public string Etag { get; set; }
        public string VolumeInfoId { get; set; }
        public string SaleInfoId { get; set; }
        public string SearchInfoId { get; set; }
    }
}
