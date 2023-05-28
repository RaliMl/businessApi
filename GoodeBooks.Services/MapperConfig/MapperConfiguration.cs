using AutoMapper;
using GoodeBooks.Models.Entities;
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

        }
    }
}
