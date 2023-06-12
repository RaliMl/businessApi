using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.Authors;
using GoodeBooks.Services.ViewModels.Authors;
using GoodeBooks.Services.ViewModels.SaleInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceImplementations
{
    public class AuthorService : IAuthorService
    {
        private readonly BookstoreDbContext context;

        private readonly IMapper mapper;
        public AuthorService(BookstoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Create(AuthorCreateViewModel model)
        {
            try
            {
                var author = mapper.Map<Author>(model);
                var volumeInfoIds = model.VolumeInfoIds.Split(',').ToList();
                author.VolumeInfos = context.VolumeInfos.Where(x => volumeInfoIds.Contains(x.Id)).ToList();

                context.Authors.Add(author);

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
        }

        public int Delete(string id)
        {
            try
            {
                context.Authors.Remove(context.Authors.FirstOrDefault(e => e.Id == id));

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
        }

        public ICollection<AuthorViewModel> GetAll()
        {
            try { return mapper.Map<List<AuthorViewModel>>(context.Authors); }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public AuthorViewModel GetById(string id)
        {
            try
            {
                var author = context.Authors.FirstOrDefault(x => x.Id == id);


                var res = mapper.Map<AuthorViewModel>(author);

                res.VolumeInfoTitles = string.Join(",", author.VolumeInfos.Select(x => x.Title));

                return res;
            }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public AuthorViewModel GetByName(string name)
        {
            try
            {
                var author = context.Authors.FirstOrDefault(x => x.Name.Contains(name));

                var res = mapper.Map<AuthorViewModel>(author);

                res.VolumeInfoTitles = string.Join(",", author.VolumeInfos.Select(x => x.Title));

                return res;
            }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public int Update(AuthorViewModel model)
        {
            try
            {
                var author = context.Authors.FirstOrDefault(x => x.Id == model.Id);

                if (author != null)
                {
                    author.Name = model.Name;

                    var volumeTitles = model.VolumeInfoTitles.Split(',').ToList();

                    author.VolumeInfos = context.VolumeInfos
                        .Where(x => volumeTitles.Contains(x.Title))
                        .GroupBy(x => x.Id)
                        .Select(g => g.FirstOrDefault())
                        .ToList();

                    context.Authors.Update(author);

                    context.SaveChanges();

                    return 1;
                }
                return -1;
            }
            catch (Exception e) { return -1; }
        }
    }
}
