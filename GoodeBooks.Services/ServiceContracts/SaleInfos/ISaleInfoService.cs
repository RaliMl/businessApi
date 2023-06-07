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
        public int Create(SaleInfoCreateViewModel model);
        public SaleInfoViewModel GetById(string id);
        public int Update(SaleInfoViewModel model);
        public ICollection<SaleInfoViewModel> GetAll();
        public int Delete(string id);
    }
}
