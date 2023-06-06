using GoodeBooks.Services.ViewModels.Volumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceContracts.Volumes
{
    public interface IVolumeService
    {
        public int Create(VolumeCreateViewModel model);
        public VolumeViewModel GetById(string id);
        public int Update(string id, VolumeUpdateViewModel model);
        public ICollection<VolumeGetViewModel> GetAll();
        public int Delete(string id);
    }
}
