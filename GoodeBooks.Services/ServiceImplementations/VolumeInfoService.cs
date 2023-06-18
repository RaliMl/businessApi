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

                volumeInfo.Authors = context.Authors.Where(x => model.AuthorIds.Contains(x.Id)).ToList();

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

        public ICollection<VolumeInfoViewModel> GetAll()
        {
            try { return mapper.Map<List<VolumeInfoViewModel>>(context.VolumeInfos); }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public VolumeInfoViewModel GetById(string id)
        {
            try
            {
                var volumeInfo = context.VolumeInfos.FirstOrDefault(x => x.Id == id);

                var res = mapper.Map<VolumeInfoViewModel>(volumeInfo);
                res.Authors = string.Join(", ", volumeInfo.Authors.Select(x => x.Name).ToList());

                return res;
            }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public int Update(VolumeInfoViewModel model)
        {
            try
            {
                var volumeInfo = context.VolumeInfos.FirstOrDefault(x => x.Id == model.Id); 

                if (volumeInfo != null)
                {
                    volumeInfo.Subtitle = model.Subtitle;
                    volumeInfo.Title = model.Title;
                    volumeInfo.Description = model.Description;

                    var authors = context.Authors.Where(x => model.Authors.Contains(x.Name)).ToList();
                    if(!volumeInfo.Authors.Equals(authors))
                        volumeInfo.Authors = context.Authors.Where(x => model.Authors.Contains(x.Name)).ToList();

                    volumeInfo.PublishedDate = model.PublishedDate;
                    volumeInfo.PageCount = model.PageCount;
                    volumeInfo.Language = model.Language;

                    context.VolumeInfos.Update(volumeInfo);

                    return context.SaveChanges();
                }
                return -1;
            }
            catch (Exception e) { return -1; }
        }
    }
}
