using GoodeBooks.Services.ModelContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Volumes
{
    public class VolumeUpdateViewModel
    {
        public string Id { get; set; }
        public string VolumeInfoId { get; set; }
        public string SaleInfoId { get; set; }
        public string SearchInfoId { get; set; }
    }
}
