
using Microsoft.AspNetCore.Identity;

namespace GoodeBooks.Models.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public virtual ICollection<Bookshelf> Bookshelves { get; set; }
    }
}
