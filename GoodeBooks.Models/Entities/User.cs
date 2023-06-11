
using Microsoft.AspNetCore.Identity;

namespace GoodeBooks.Models.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public virtual ICollection<Bookshelf> Bookshelves { get; set; }
    }
}
