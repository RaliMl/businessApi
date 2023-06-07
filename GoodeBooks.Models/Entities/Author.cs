using GoodeBooks.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Models.Entities
{
    public class Author : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<VolumeInfo> VolumeInfos { get; set; }
    }
}
