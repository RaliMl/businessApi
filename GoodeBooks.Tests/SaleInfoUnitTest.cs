using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.SaleInfos;
using GoodeBooks.Services.ServiceContracts.VolumeInfos;
using GoodeBooks.Services.ServiceImplementations;
using GoodeBooks.Services.ViewModels.SaleInfos;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GoodeBooks.Tests
{
    [TestClass]
    public class SaleInfoUnitTest
    {
        private SaleInfoCreateViewModel createModel;
        private SaleInfoUpdateViewModel updateModel;
        private ISaleInfoService service;
        public void Arrange()
        {
            createModel = new SaleInfoCreateViewModel()
            {
                Country = "United States",
                SaleAbility = "Available",
                IsEbook = true
            };

            updateModel = new SaleInfoUpdateViewModel()
            {
                Country = "United States",
                SaleAbility = "Available",
                IsEbook = false
            };

            var options = new DbContextOptionsBuilder<BookstoreDbContext>()
          .UseInMemoryDatabase(databaseName: "GoodeBooksDb")
          .Options;
            BookstoreDbContext dbContext = new BookstoreDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<SaleInfo, SaleInfoCreateViewModel>().ReverseMap();
                x.CreateMap<SaleInfo, SaleInfoViewModel>().ReverseMap();
                x.CreateMap<SaleInfo, SaleInfoUpdateViewModel>().ReverseMap();

            });
            Mapper mapper = new Mapper(configuration);
            service = new SaleInfoService(dbContext, mapper);
        }
        [Fact]
        public void Create_SaleInfo_Success()
        {
            Arrange();

            var res = service.Create(createModel);

            Xunit.Assert.Equal(1, res);
        }

        [Fact]
        public void GetAll_SaleInfo_Success()
        {
            Arrange();

            service.Create(createModel);
            var res = service.GetAll();

            Xunit.Assert.NotEmpty(res);
        }

        [Fact]
        public void Delete_SaleInfo_Success()
        {
            Arrange();

            var info = service.GetAll();
            var res = service.Delete(info.First().Id);

            Xunit.Assert.Equal(1, res);
        }

        [Fact]
        public void GetById_SaleInfo_Success()
        {
            Arrange();

            var info = service.GetAll();
            var res = service.GetById(info.First().Id);

            Xunit.Assert.Equal("United States", res.Country);
        }

        //[Fact]
        //public void Update_SaleInfo_Success()
        //{
        //    Arrange();

        //    var info = service.GetAll();
        //    var res = service.Update(info.First().Id, updateModel);

        //    Xunit.Assert.Equal(1, res);
        //}
    }
}
