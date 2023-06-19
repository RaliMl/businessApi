using GoodeBooks.Services.ViewModels.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceContracts.Authors
{
    public interface IAuthorService
    {
        public int Create(AuthorCreateViewModel model);
        public AuthorViewModel GetById(string id);
        public AuthorViewModel GetByName(string name);
        public ICollection<AuthorViewModel> Search(string searchTerm);
        public int Update(AuthorViewModel model);
        public ICollection<AuthorViewModel> GetAll();
        public int Delete(string id);
    }
}
