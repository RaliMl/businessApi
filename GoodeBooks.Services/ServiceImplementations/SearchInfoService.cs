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
        public int Create(SearchInfoCreateViewModel model)
        {
            try
            {
                var searchInfo = mapper.Map<SearchInfo>(model);

                context.SearchInfos.Add(searchInfo);

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
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

        public ICollection<SearchInfoGetViewModel> GetAll()
        {
            try { return mapper.Map<List<SearchInfoGetViewModel>>(context.SearchInfos); }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public SearchInfoGetViewModel GetById(string id)
        {
            try
            {
                var res = mapper.Map<SearchInfoGetViewModel>(context.SearchInfos.FirstOrDefault(x => x.Id == id));

                return res;
            }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public int Update(string id, SearchInfoUpdateViewModel model)
        {
            try
            {
                var searchInfo = context.SearchInfos.FirstOrDefault(x => x.Id == id);

                if (searchInfo != null)
                {
                    context.Set<SearchInfo>().Update(searchInfo);

                    return context.SaveChanges();
                }
                return -1;
            }
            catch (Exception e) { return -1; }
        }
    }
}
