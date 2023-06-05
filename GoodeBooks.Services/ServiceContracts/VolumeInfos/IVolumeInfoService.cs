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
        public VolumeInfoGetViewModel GetById(string id);
        public int Update(string id, VolumeInfoUpdateViewModel model);
        public ICollection<VolumeInfoGetViewModel> GetAll();
        public int Delete(string id);
    }
}
