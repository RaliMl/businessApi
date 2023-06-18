using GoodeBooks.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Models.Entities
{
    public class StarRate : BaseModel
    {
        public virtual User User { get; set; }
        public string Name { get; set; }
        public virtual Volume Volume { get; set; }
        public int Rate { get; set; }
    }
}
