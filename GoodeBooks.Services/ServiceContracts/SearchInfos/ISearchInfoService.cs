using GoodeBooks.Services.ViewModels.SearchInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceContracts.SearchInfos
{
    public interface ISearchInfoService
    {
        public int Create(SearchInfoCreateViewModel model);
        public SearchInfoGetViewModel GetById(string id);
        public int Update(string id, SearchInfoUpdateViewModel model);
        public ICollection<SearchInfoGetViewModel> GetAll();
        public int Delete(string id);
    }
}
