using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.SaleInfos;
using GoodeBooks.Services.ServiceContracts.SearchInfos;
using GoodeBooks.Services.ServiceImplementations;
using GoodeBooks.Services.ViewModels.SaleInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GoodeBooks.Tests
{
    [TestClass]
    public class SearchInfoUnitTests
    {
        private SearchInfoCreateViewModel createModel;
        private SearchInfoUpdateViewModel updateModel;
        private ISearchInfoService service;
        public void Arrange()
        {
            createModel = new SearchInfoCreateViewModel()
            {
                TextSnippet = "Gatsby"
            };

            updateModel = new SearchInfoUpdateViewModel()
            {
                TextSnippet = "Great"
            };

            var options = new DbContextOptionsBuilder<BookstoreDbContext>()
          .UseInMemoryDatabase(databaseName: "GoodeBooksDb")
          .Options;
            BookstoreDbContext dbContext = new BookstoreDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<SearchInfo, SearchInfoCreateViewModel>().ReverseMap();
                x.CreateMap<SearchInfo, SearchInfoGetViewModel>().ReverseMap();
                x.CreateMap<SearchInfo, SearchInfoUpdateViewModel>().ReverseMap();

            });
            Mapper mapper = new Mapper(configuration);
            service = new SearchInfoService(dbContext, mapper);
        }
        [Fact]
        public void Create_SearchInfo_Success()
        {
            Arrange();

            var res = service.Create(createModel);

            Xunit.Assert.Equal(1, res);
        }

        [Fact]
        public void GetAll_SearchInfo_Success()
        {
            Arrange();

            service.Create(createModel);
            var res = service.GetAll();

            Xunit.Assert.Equal(1, res.Count());
        }

        [Fact]
        public void Delete_SearchInfo_Success()
        {
            Arrange();

            var info = service.GetAll();
            var res = service.Delete(info.First().Id);

            Xunit.Assert.Equal(1, res);
        }

        [Fact]
        public void GetById_SearchInfo_Success()
        {
            Arrange();

            var info = service.GetAll();
            var res = service.GetById(info.First().Id);

            Xunit.Assert.Equal("Gatsby", res.TextSnippet);
        }

        [Fact]
        public void Update_SearchInfo_Success()
        {
            Arrange();

            service.Create(createModel);
            var info = service.GetAll();
            var res = service.Update(info.First().Id, updateModel);

            Xunit.Assert.Equal(1, res);
        }
    }
}
