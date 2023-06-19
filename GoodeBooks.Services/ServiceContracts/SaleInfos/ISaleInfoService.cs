using GoodeBooks.Services.ViewModels.SaleInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceContracts.SaleInfos
{
    public interface ISaleInfoService
    {
        public string Create(SaleInfoCreateViewModel model);
        public SaleInfoViewModel GetById(string id);

        public ICollection<SaleInfoViewModel> Search(string searchTerm);
        public int Update(SaleInfoViewModel model);
        public ICollection<SaleInfoViewModel> GetAll();
        public int Delete(string id);
    }
}
