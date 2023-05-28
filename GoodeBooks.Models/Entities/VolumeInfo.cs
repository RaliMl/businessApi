using GoodeBooks.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Models.Entities
{
    public class VolumeInfo : BaseModel    
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public ICollection<Author> Authors { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
        public Volume Volume { get; set; }
    }
}
