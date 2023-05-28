using GoodeBooks.Services.ModelContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Volumes
{
    public class VolumeGetViewModel : BaseViewModel, IVolumeViewModel
    {
        public string Kind { get; set; }
        public string Etag { get; set; }
        public string VolumeInfoId { get; set; }
        public string SaleInfoId { get; set; }
        public string SearchInfoId { get; set; }
    }
}
