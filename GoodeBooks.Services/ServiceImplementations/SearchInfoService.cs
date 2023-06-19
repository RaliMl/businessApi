using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.SearchInfos;
using GoodeBooks.Services.ViewModels.SaleInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceImplementations
{
    public class SearchInfoService : ISearchInfoService
    {
        private readonly BookstoreDbContext context;

        private readonly IMapper mapper;
        public SearchInfoService(BookstoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public string Create(SearchInfoCreateViewModel model)
        {
            try
            {
                var searchInfo = mapper.Map<SearchInfo>(model);

                context.SearchInfos.Add(searchInfo);

                context.SaveChanges();

                return searchInfo.Id;
            }
            catch (Exception ex) { return null; }
        }

        public int Delete(string id)
        {
            try
            {
                context.SearchInfos.Remove(context.SearchInfos.FirstOrDefault(e => e.Id == id));

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
        }

        public ICollection<SearchInfoViewModel> GetAll()
        {
            try { return mapper.Map<List<SearchInfoViewModel>>(context.SearchInfos); }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public SearchInfoViewModel GetById(string id)
        {
            try
            {
                var res = mapper.Map<SearchInfoViewModel>(context.SearchInfos.FirstOrDefault(x => x.Id == id));

                return res;
            }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public int Update(SearchInfoViewModel model)
        {
            try
            {
                var searchInfo = context.SearchInfos.FirstOrDefault(x => x.Id == model.Id);

                if (searchInfo != null)
                {
                    searchInfo.TextSnippet = model.TextSnippet;

                    context.SearchInfos.Update(searchInfo);

                    return context.SaveChanges();
                }
                return -1;
            }
            catch (Exception e) { return -1; }
        }
    }
}
