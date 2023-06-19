using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.Authors;
using GoodeBooks.Services.ViewModels.Authors;
using GoodeBooks.Services.ViewModels.SaleInfos;
using GoodeBooks.Services.ViewModels.Volumes;
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

        public ICollection<AuthorViewModel> Search(string searchTerm)
        {
            var authors = context.Authors.Where(x => x.Name.Contains(searchTerm)).ToList();

            if (authors != null)
            {
                var res = mapper.Map<List<AuthorViewModel>>(authors);

                for (int i = 0; i < res.Count; i++)
                    res[i].VolumeInfoTitles = string.Join(",", authors[i].VolumeInfos.Select(x => x.Title));

                return res;
            }
            return null;
        }
        public int Create(AuthorCreateViewModel model)
        {
            try
            {
                var mappedAuthor = mapper.Map<Author>(model);
                var authors = model.Names.Split(',').ToList();
                foreach (var author in authors)
                {
                    if (model.VolumeInfoIds != null)
                    {
                        var volumeInfoIds = model.VolumeInfoIds.Split(',').ToList();
                        mappedAuthor.VolumeInfos = context.VolumeInfos.Where(x => volumeInfoIds.Contains(x.Id)).ToList();
                    }
                    else
                        mappedAuthor.VolumeInfos = new List<VolumeInfo>();
                    mappedAuthor.Name = author;

                    context.Authors.Add(mappedAuthor);
                }

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
            try 
            {
                var authors = context.Authors.ToList();

                if(authors != null)
                {
                    var res = mapper.Map<List<AuthorViewModel>>(authors);

                    for(int i = 0; i< res.Count; i++)
                        res[i].VolumeInfoTitles = string.Join(",", authors[i].VolumeInfos.Select(x => x.Title));
                    return res;
                }
                return null;
                 
            }
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
