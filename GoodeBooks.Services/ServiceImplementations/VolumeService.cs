using AutoMapper;
using Azure.Core;
using Cars.Services.MapperConfig;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.Volumes;
using GoodeBooks.Services.ViewModels.Volumes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceImplementations
{
    public class VolumeService : IVolumeService
    {
        private readonly BookstoreDbContext context;

        private readonly IMapper mapper;

        public VolumeService(BookstoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        
        public int Create(VolumeCreateViewModel model)
        {
            try
            {
                var volume = mapper.Map<Volume>(model);

                volume.VolumeInfo = context.VolumeInfos.FirstOrDefault(s => s.Id == model.VolumeInfoId);
                volume.SaleInfo = context.SaleInfos.FirstOrDefault(s => s.Id == model.SaleInfoId);
                volume.SearchInfo = context.SearchInfos.FirstOrDefault(s => s.Id == model.SearchInfoId);

                context.Volumes.Add(volume); 

                context.SaveChanges();

                return 1;
            }
            catch (Exception e) { return -1; }
        }

        public int Delete(string id)
        {
            try
            {
                context.Volumes.Remove(context.Volumes.FirstOrDefault(e => e.Id == id));

                context.SaveChanges();

                return 1;
            }
            catch(Exception e) { return -1; }
        }

        public ICollection<VolumeGetViewModel> GetAll()
        {
            try { return mapper.Map<List<VolumeGetViewModel>>(context.Volumes); }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public VolumeViewModel GetById(string id)
        {
            try
            {
                var volume = context.Volumes.FirstOrDefault(x => x.Id == id);
                var res = mapper.Map<VolumeViewModel>(volume);
                res.VolumeName = volume.VolumeInfo.Title;
                res.Country = volume.SaleInfo.Country;
                res.TextSnippet = volume.SearchInfo.TextSnippet;

                return res;
            }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public int Update(string id, VolumeUpdateViewModel model)
        {
            try
            {
                 Volume volume = context.Volumes.FirstOrDefault(x => x.Id == id);

                if (model != null)
                {

                    volume.VolumeInfo = context.VolumeInfos.FirstOrDefault(x => x.Id == model.VolumeInfoId);
                    volume.SaleInfo = context.SaleInfos.FirstOrDefault(x => x.Id == model.SaleInfoId);
                    volume.SearchInfo = context.SearchInfos.FirstOrDefault(x => x.Id == model.SearchInfoId);
                    context.Set<Volume>().Update(volume);

                    return context.SaveChanges();
                }
                return -1;
            }
            catch (Exception e) { return -1; }
        }
    }
}
