using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.VolumeInfos;
using GoodeBooks.Services.ServiceContracts.Volumes;
using GoodeBooks.Services.ServiceImplementations;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using GoodeBooks.Services.ViewModels.Volumes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GoodeBooks.Tests.Volumes
{
    [TestClass]
    public class VolumeInfoUnitTests
    {
        private VolumeInfoCreateViewModel createModel;
        private IVolumeInfoService service;
        public void Arrange()
        {
            createModel = new VolumeInfoCreateViewModel();
            createModel.Title = "The Great Gatsby";
            createModel.Subtitle = "A Novel";
            createModel.AuthorIds = new List<string>() { "author123", "author456" };
            createModel.PublishedDate = DateTime.Parse("2022-03-15");
            createModel.Description = "The Great Gatsby is a novel written by F. Scott Fitzgerald.";
            createModel.PageCount = 180;
            createModel.Language = "English";
            // createModel.VolumeId = "volume789";

            

            var options = new DbContextOptionsBuilder<BookstoreDbContext>()
          .UseInMemoryDatabase(databaseName: "GoodeBooksDb")
          .Options;
            BookstoreDbContext dbContext = new BookstoreDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<VolumeInfo, VolumeInfoCreateViewModel>().ReverseMap();
                x.CreateMap<VolumeInfo, VolumeInfoViewModel>().ReverseMap();

            });
            Mapper mapper = new Mapper(configuration);
            service = new VolumeInfoService(dbContext, mapper);
        }

        [Fact]
        public void Create_VolumeInfo_Success()
        {
            Arrange();

            var res = service.Create(createModel);

            Xunit.Assert.Equal(1, res);
        }

        [Fact]
        public void GetAll_VolumeInfo_Success()
        {
            Arrange();

            service.Create(createModel);
            var res = service.GetAll();

            Xunit.Assert.NotEmpty(res);
        }

        [Fact]
        public void Delete_VolumeInfo_Success()
        {
            Arrange();

            var info = service.GetAll();
            var res = service.Delete(info.First().Id);

            Xunit.Assert.Equal(1, res);
        }

        [Fact]
        public void GetById_VolumeInfo_Success()
        {
            Arrange();

            var info = service.GetAll();
            var res = service.GetById(info.First().Id);

            Xunit.Assert.Equal("The Great Gatsby", res.Title);
        }

        //[Fact]
        //public void Update_VolumeInfo_Success()
        //{
        //    Arrange();

        //    var info = service.GetAll();
        //    var res = service.Update(model);

        //    Xunit.Assert.Equal(1, res);
        //}
    }
}
