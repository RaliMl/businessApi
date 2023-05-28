using AutoMapper;
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

                volume = context.Volumes.Include("VolumeInfo").First();
                volume = context.Volumes.Include("SearchInfo").First();
                volume = context.Volumes.Include("SaleInfo").First();

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

        public VolumeGetViewModel GetById(string id)
        {
            try
            { 
                var res = mapper.Map<VolumeGetViewModel>(context.Volumes.FirstOrDefault(x => x.Id == id));

                return res;
            }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public int Update(VolumeUpdateViewModel model)
        {
            try
            {
                var entity = mapper.Map<Volume>(model);

                if (entity != null)
                {
                    
                    context.Set<Volume>().Update(entity);

                    return context.SaveChanges();
                }
                return -1;
            }
            catch (Exception e) { return -1; }
        }
    }
}
