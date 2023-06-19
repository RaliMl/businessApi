using GoodeBooks.Models.BaseModels;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ModelContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Volumes
{
    public class VolumeCreateViewModel : IVolumeViewModel
    {
        [RegularExpression("^(volume)$", ErrorMessage = "The kind must be 'volume'")]
        [Required]
        public string Kind { get; set; }
        [Required]
        public string Etag { get; set; }
        [Required]
        public string VolumeInfotTitle { get; set; }
        [Required]
        public string SaleInfoId { get; set; }
        [Required]
        public string SearchInfoId { get; set; }
        public string? BookshelfIds { get; set; }
    }
}
