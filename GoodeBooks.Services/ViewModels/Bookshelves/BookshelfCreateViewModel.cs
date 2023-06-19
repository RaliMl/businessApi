using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Bookshelves
{
    public class BookshelfCreateViewModel
    {
        [RegularExpression("^(bookshelf)$", ErrorMessage = "The kind must be 'bookshelf'")]
        public string Kind { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
        public int VolumeCount { get; set; }
        public string? VolumeNames { get; set; }
    }
}
