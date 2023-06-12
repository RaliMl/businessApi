using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.SaleInfos
{
    public class SaleInfoCreateViewModel
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string SaleAbility { get; set; }
        [Required]
        public bool IsEbook { get; set; }
    }
}
