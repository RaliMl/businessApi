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
        public string Create(SearchInfoCreateViewModel model);
        public SearchInfoViewModel GetById(string id);
        public int Update(SearchInfoViewModel model);
        public ICollection<SearchInfoViewModel> GetAll();
        public int Delete(string id);
    }
}
