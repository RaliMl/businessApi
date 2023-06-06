using AutoMapper;
using Azure;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.SaleInfos;
using GoodeBooks.Services.ServiceContracts.SearchInfos;
using GoodeBooks.Services.ServiceContracts.VolumeInfos;
using GoodeBooks.Services.ServiceContracts.Volumes;
using GoodeBooks.Services.ServiceImplementations;
using GoodeBooks.Services.ViewModels.SaleInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using GoodeBooks.Services.ViewModels.Volumes;
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
    public class VolumeUnitTests
    {
        private VolumeCreateViewModel createModel;
        private VolumeUpdateViewModel updateModel;

        private VolumeInfoCreateViewModel volumeInfo;

        private SaleInfoCreateViewModel saleInfo;

        private SearchInfoCreateViewModel searchInfo;

        private IVolumeService service;
        private IVolumeInfoService volumeInfoService;
        private ISearchInfoService searchInfoService;
        private ISaleInfoService saleInfoService;

        public void Arrange()
        {           

            var options = new DbContextOptionsBuilder<BookstoreDbContext>()
          .UseInMemoryDatabase(databaseName: "GoodeBooksDb")
          .Options;
            BookstoreDbContext dbContext = new BookstoreDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Volume, VolumeCreateViewModel>().ReverseMap();
                x.CreateMap<Volume, VolumeGetViewModel>().ReverseMap();
                x.CreateMap<Volume, VolumeUpdateViewModel>().ReverseMap();

                x.CreateMap<VolumeInfo, VolumeInfoCreateViewModel>().ReverseMap();
                x.CreateMap<VolumeInfo, VolumeInfoGetViewModel>().ReverseMap();
                x.CreateMap<VolumeInfo, VolumeInfoUpdateViewModel>().ReverseMap();

                x.CreateMap<SaleInfo, SaleInfoCreateViewModel>().ReverseMap();
                x.CreateMap<SaleInfo, SaleInfoGetViewModel>().ReverseMap();
                x.CreateMap<SaleInfo, SaleInfoUpdateViewModel>().ReverseMap();

                x.CreateMap<SearchInfo, SearchInfoCreateViewModel>().ReverseMap();
                x.CreateMap<SearchInfo, SearchInfoGetViewModel>().ReverseMap();
                x.CreateMap<SearchInfo, SearchInfoUpdateViewModel>().ReverseMap();

            });
            Mapper mapper = new Mapper(configuration);
            service = new VolumeService(dbContext, mapper);
            saleInfoService = new SaleInfoService(dbContext, mapper);
            searchInfoService = new SearchInfoService(dbContext, mapper);
            volumeInfoService = new VolumeInfoService(dbContext, mapper);

            saleInfo = new SaleInfoCreateViewModel()
            {
                Country = "United States",
                SaleAbility = "Available",
                IsEbook = true
            };

            //saleInfoService.Create(saleInfo);
            //string saleInfoId = saleInfoService.GetAll().First().Id;

            volumeInfo = new VolumeInfoCreateViewModel()
            {
                Title = "The Great Gatsby",
                Subtitle = "A Novel",
                AuthorIds = new List<string>() { "author123", "author456" },
                PublishedDate = DateTime.Parse("2022-03-15"),
                Description = "The Great Gatsby is a novel written by F. Scott Fitzgerald.",
                PageCount = 180,
                Language = "English"
            };

            //volumeInfoService.Create(volumeInfo);
            //string volumeInfoId = volumeInfoService.GetAll().First().Id;


            searchInfo = new SearchInfoCreateViewModel()
            {
                TextSnippet = "Gatsby"
            };

            //searchInfoService.Create(searchInfo);
            //string searchInfoId = searchInfoService.GetAll().First().Id;

            //createModel = new VolumeCreateViewModel()
            //{
            //    Kind = "book",
            //    Etag = "WxZ123456",
            //    VolumeInfoId = volumeInfoId,
            //    SaleInfoId = saleInfoId,
            //    SearchInfoId = searchInfoId
            //};

            //updateModel = new VolumeUpdateViewModel()
            //{
            //    VolumeInfoId = volumeInfoId,
            //    SaleInfoId = saleInfoId,
            //    SearchInfoId = searchInfoId
            //};
        }
        [Fact]
        public void Create_Volume_Success()
        {
            Arrange();

            saleInfoService.Create(saleInfo);
            string saleInfoId = saleInfoService.GetAll().First().Id;

            volumeInfoService.Create(volumeInfo);
            string volumeInfoId = volumeInfoService.GetAll().First().Id;

            searchInfoService.Create(searchInfo);
            string searchInfoId = searchInfoService.GetAll().First().Id;

            createModel = new VolumeCreateViewModel()
            {
                Kind = "book",
                Etag = "WxZ123456",
                VolumeInfoId = volumeInfoId,
                SaleInfoId = saleInfoId,
                SearchInfoId = searchInfoId
            };

            updateModel = new VolumeUpdateViewModel()
            {
                VolumeInfoId = volumeInfoId,
                SaleInfoId = saleInfoId,
                SearchInfoId = searchInfoId
            };

            var res = service.Create(createModel);

            Xunit.Assert.Equal(1, res);
        }

        //[Fact]
        //public void GetAll_Volume_Success()
        //{
        //    Arrange();

        //    service.Create(createModel);
        //    var res = service.GetAll();

        //    Xunit.Assert.Equal(1, res.Count());
        //}

        //[Fact]
        //public void Delete_Volume_Success()
        //{
        //    Arrange();

        //    var info = service.GetAll();
        //    var res = service.Delete(info.First().Id);

        //    Xunit.Assert.Equal(1, res);
        //}

        //[Fact]
        //public void GetById_Volume_Success()
        //{
        //    Arrange();

        //    var info = service.GetAll();
        //    var res = service.GetById(info.First().Id);

        //    Xunit.Assert.Equal("book", res.Kind);
        //}

        //[Fact]
        //public void Update_Volume_Success()
        //{
        //    Arrange();

        //    service.Create(createModel);
        //    var info = service.GetAll();
        //    var res = service.Update(info.First().Id, updateModel);

        //    Xunit.Assert.Equal(1, res);
        //}
    }
}
