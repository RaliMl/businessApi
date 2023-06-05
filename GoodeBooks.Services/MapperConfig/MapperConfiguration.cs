using AutoMapper;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using GoodeBooks.Services.ViewModels.Volumes;

namespace Cars.Services.MapperConfig
{
    public class MapperConfiguration:Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Volume, VolumeGetViewModel>().ReverseMap();
            CreateMap<Volume, VolumeUpdateViewModel>().ReverseMap();
            CreateMap<Volume, VolumeCreateViewModel>().ReverseMap();

            CreateMap<VolumeInfo, VolumeInfoCreateViewModel>().ReverseMap();
            CreateMap<VolumeInfo, VolumeInfoGetViewModel>().ReverseMap();
            CreateMap<Volume, VolumeInfoUpdateViewModel>().ReverseMap();
        }
    }
}
