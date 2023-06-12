using GoodeBooks.Services.ModelContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Volumes
{
    public class VolumeUpdateViewModel
    {
        public string Id { get; set; }
        [Required]
        public string VolumeInfoId { get; set; }
        [Required]
        public string SaleInfoId { get; set; }
        [Required]
        public string SearchInfoId { get; set; }
        public string BookshelfIds { get; set; }
    }
}
