using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.VolumeInfos;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using GoodeBooks.Services.ViewModels.Volumes;
using Google.Apis.Books.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceImplementations
{
    public class VolumeInfoService : IVolumeInfoService
    {
        private readonly BookstoreDbContext context;

        private readonly IMapper mapper;
        public VolumeInfoService(BookstoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Create(VolumeInfoCreateViewModel model)
        {
            try
            {
                var volumeInfo = mapper.Map<VolumeInfo>(model);

                context.VolumeInfos.Add(volumeInfo);

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
        }

        public int Delete(string id)
        {
            try
            {
                context.VolumeInfos.Remove(context.VolumeInfos.FirstOrDefault(e => e.Id == id));

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
        }

        public ICollection<VolumeInfoGetViewModel> GetAll()
        {
            try { return mapper.Map<List<VolumeInfoGetViewModel>>(context.VolumeInfos); }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public VolumeInfoGetViewModel GetById(string id)
        {
            try
            {
                var res = mapper.Map<VolumeInfoGetViewModel>(context.VolumeInfos.FirstOrDefault(x => x.Id == id));

                return res;
            }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public int Update(string id, VolumeInfoUpdateViewModel model)
        {
            try
            {
                var volumeInfo = context.VolumeInfos.FirstOrDefault(x => x.Id == id);

                if (volumeInfo != null)
                {
                    context.Set<VolumeInfo>().Update(volumeInfo);

                    return context.SaveChanges();
                }
                return -1;
            }
            catch (Exception e) { return -1; }
        }
    }
}
