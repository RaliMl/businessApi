using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoodeBooks.Models.Entities.APIEntities
{
    public class GoogleVolumeInfo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public virtual ICollection<string> Authors { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
        public GoogleImageLinks ImageLinks { get; set; }
    }

   
}
