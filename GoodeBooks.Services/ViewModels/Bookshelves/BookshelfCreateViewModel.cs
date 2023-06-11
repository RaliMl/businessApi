using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Bookshelves
{
    public class BookshelfCreateViewModel
    {
        public string Kind { get; set; }
        public string Title { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
        public int VolumeCount { get; set; }
        public string VolumeNames { get; set; }
    }
}
