using AutoMapper;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ViewModels.Authors;
using GoodeBooks.Services.ViewModels.Bookshelves;
using GoodeBooks.Services.ViewModels.SaleInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using GoodeBooks.Services.ViewModels.Volumes;

namespace Cars.Services.MapperConfig
{
    public class MapperConfiguration:Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Volume, VolumeViewModel>().ReverseMap();
            CreateMap<Volume, VolumeUpdateViewModel>().ReverseMap();
            CreateMap<Volume, VolumeCreateViewModel>().ReverseMap();

            CreateMap<VolumeInfo, VolumeInfoCreateViewModel>().ReverseMap();
            CreateMap<VolumeInfo, VolumeInfoViewModel>().ReverseMap();

            CreateMap<SaleInfo, SaleInfoCreateViewModel>().ReverseMap();
            CreateMap<SaleInfo, SaleInfoViewModel>().ReverseMap();
            CreateMap<SaleInfo, SaleInfoUpdateViewModel>().ReverseMap();

            CreateMap<SearchInfo, SearchInfoCreateViewModel>().ReverseMap();
            CreateMap<SearchInfo, SearchInfoViewModel>().ReverseMap();

            CreateMap<Author, AuthorCreateViewModel>().ReverseMap();
            CreateMap<Author, AuthorViewModel>().ReverseMap();

            CreateMap<Bookshelf, BookshelfCreateViewModel>().ReverseMap();
            CreateMap<Bookshelf, BookshelfViewModel>().ReverseMap();
        }
    }
}
