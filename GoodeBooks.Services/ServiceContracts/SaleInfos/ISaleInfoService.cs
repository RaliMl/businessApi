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
        public SaleInfoGetViewModel GetById(string id);
        public int Update(string id, SaleInfoUpdateViewModel model);
        public ICollection<SaleInfoGetViewModel> GetAll();
        public int Delete(string id);
    }
}
