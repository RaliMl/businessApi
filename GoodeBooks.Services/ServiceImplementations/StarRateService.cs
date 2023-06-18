using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.StarRate;
using GoodeBooks.Services.ViewModels.StarRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceImplementations
{
    public class StarRateService : IStarRateService
    {
        private readonly BookstoreDbContext context;

        private readonly IMapper mapper;

        public StarRateService(BookstoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int AddRating(StarRateCreateViewModel model)
        {
            try
            {
                var user = context.Users.FirstOrDefault(x => x.Id == model.UserId);
                var volume = context.Volumes.FirstOrDefault(x => x.VolumeInfo.Title == model.VolumeTitle);

                var res = mapper.Map<StarRate>(model);
                res.User = user;
                res.Name = user.Name;
                res.Volume = volume;

                volume.AverageRate = (volume.AverageRate + res.Rate) / 2;

                context.Volumes.Update(volume);

                var check = context.Ratings.FirstOrDefault(x => (x.Name == res.Name && x.Volume.VolumeInfo.Title == res.Volume.VolumeInfo.Title)) == null;
                if (!check)
                {
                    var found = context.Ratings.FirstOrDefault(x => x.Name == res.Name && x.Volume.VolumeInfo.Title == res.Volume.VolumeInfo.Title);
                    found.Rate = res.Rate;
                    context.Ratings.Update(found);
                }
                else
                    context.Ratings.Add(res);

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
        }
    }
}
