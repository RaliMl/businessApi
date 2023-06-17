using GoodeBooks.Services.ViewModels.Authors;
using GoodeBooks.Services.ViewModels.Bookshelves;
using GoodeBooks.Services.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceContracts
{
    public interface IUserService
    {
        public bool GiveRole(string roleName);
        public Task<int> Create(UserCreateViewModel model);
        public bool AssignBookshelf(UserBookshelfIdsViewModel model);
        public UserViewModel GetById(string id);
        public ICollection<UserViewModel> GetAll();
        public int Delete(string id);
        public int Update(UserViewModel model);
    }
}
