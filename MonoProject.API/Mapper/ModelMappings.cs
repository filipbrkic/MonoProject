using AutoMapper;
using MonoProject.API.Models;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;

namespace MonoProject.API.Mapper
{
    public class ModelMappings : Profile
    {
        public ModelMappings()
        {
            CreateMap<VehicleMake, VehicleMakeDTO>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();

            CreateMap<VehicleMake, VehicleParams>().ReverseMap();
            CreateMap<VehicleModel, VehicleParams>().ReverseMap();

            CreateMap<VehicleMakeDTO, VehicleParams>().ReverseMap();
            CreateMap<VehicleModelDTO, VehicleParams>().ReverseMap();

            CreateMap<Filtering, IFiltering>().ReverseMap();
            CreateMap<Paging, IPaging>().ReverseMap();
            CreateMap<Sorting, ISorting>().ReverseMap();
        }
    }
}
