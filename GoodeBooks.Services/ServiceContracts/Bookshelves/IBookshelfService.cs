using GoodeBooks.Services.ViewModels.Bookshelves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceContracts.Bookshelves
{
    public interface IBookshelfService
    {
        public int Create(BookshelfCreateViewModel model, string userId);
        public BookshelfViewModel GetById(long id);
        public ICollection<BookshelfViewModel> Search(string searchTerm);
        public int Update(BookshelfViewModel model);
        public ICollection<BookshelfViewModel> GetAll(string userId);
        public ICollection<BookshelfViewModel> GetAll();
        public int Delete(long id);
    }
}
