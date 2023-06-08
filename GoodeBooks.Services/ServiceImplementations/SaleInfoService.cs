﻿using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.SaleInfos;
using GoodeBooks.Services.ViewModels.SaleInfos;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceImplementations
{
    public class SaleInfoService : ISaleInfoService
    {
        private readonly BookstoreDbContext context;

        private readonly IMapper mapper;
        public SaleInfoService(BookstoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Create(SaleInfoCreateViewModel model)
        {
            try
            {
                var saleInfo = mapper.Map<SaleInfo>(model);

                context.SaleInfos.Add(saleInfo);

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
        }

        public int Delete(string id)
        {
            try
            {
                context.SaleInfos.Remove(context.SaleInfos.FirstOrDefault(e => e.Id == id));

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
        }

        public ICollection<SaleInfoViewModel> GetAll()
        {
            try { return mapper.Map<List<SaleInfoViewModel>>(context.SaleInfos); }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public SaleInfoViewModel GetById(string id)
        {
            try
            {
                var res = mapper.Map<SaleInfoViewModel>(context.SaleInfos.FirstOrDefault(x => x.Id == id));

                return res;
            }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public int Update(SaleInfoViewModel model)
        {
            try
            {
                var saleInfo = context.SaleInfos.FirstOrDefault(x => x.Id == model.Id);

                if (saleInfo != null)
                {
                    saleInfo.SaleAbility = model.SaleAbility;
                    saleInfo.IsEbook = model.IsEbook;
                    saleInfo.Country = model.Country;

                    context.SaleInfos.Update(saleInfo);

                    return context.SaveChanges();
                }
                return -1;
            }
            catch (Exception e) { return -1; }
        }
    }
}