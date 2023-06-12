using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.SearchInfos
{
    public class SearchInfoCreateViewModel
    {
        [Required]
        public string TextSnippet { get; set; }
    }
}
