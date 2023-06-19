using GoodeBooks.Services.ViewModels.VolumeInfos;
using GoodeBooks.Services.ViewModels.Volumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceContracts.VolumeInfos
{
    public interface IVolumeInfoService
    {
        public int Create(VolumeInfoCreateViewModel model);
        public VolumeInfoViewModel GetById(string id);
        public ICollection<VolumeInfoViewModel> Search(string searchTerm);
        public int Update(VolumeInfoViewModel model);
        public ICollection<VolumeInfoViewModel> GetAll();
        public int Delete(string id);
    }
}
