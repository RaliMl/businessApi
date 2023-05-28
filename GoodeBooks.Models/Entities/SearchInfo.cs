using GoodeBooks.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Models.Entities
{
    public class SearchInfo : BaseModel
    {
        public string TextSnippet { get; set; }
        public Volume Volume { get; set; }
    }
}
