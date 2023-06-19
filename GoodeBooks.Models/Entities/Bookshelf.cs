using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Models.Entities
{
    public class Bookshelf
    {
        public string Kind { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime Created { get; set; }
        public int VolumeCount { get; set; }
        public virtual ICollection<Volume>? Volumes { get; set; }
    }
}
