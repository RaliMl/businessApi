using GoodeBooks.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.VolumeInfos
{
    public class VolumeInfoCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Subtitle { get; set; }
        [Required]
        public string? Authors { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        public string Language { get; set; }

        public string? ImageUrl { get; set; }
    }
}
