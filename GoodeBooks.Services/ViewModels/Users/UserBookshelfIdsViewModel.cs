using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GoodeBooks.Services.ViewModels.Users
{
    public class UserBookshelfIdsViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public long BookshelfId { get; set; }
    }
}
