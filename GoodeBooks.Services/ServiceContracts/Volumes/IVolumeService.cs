﻿using GoodeBooks.Services.ViewModels.Volumes;
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
        ICollection<VolumeViewModel> Search(string searchTerm);
        public int Update(VolumeViewModel model);
        public ICollection<VolumeViewModel> GetAll();
        public int Delete(string id);
        public int AddToBookshelf(string volumeId, long bookshelfId);
    }
}
