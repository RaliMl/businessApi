using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Models.Entities.APIEntities
{
    public class GoogleBooksResponse
    {
        public int TotalItems { get; set; }
        public List<GoogleBook> Items { get; set; }
    }
}
