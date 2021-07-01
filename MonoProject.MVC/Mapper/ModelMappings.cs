using AutoMapper;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using MonoProject.MVC.Models;

namespace MonoProject.MVC.Mapper
{
    public class ModelMappings : Profile
    {
        public ModelMappings()
        {
            CreateMap<VehicleMake, VehicleMakeDTO>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();

            CreateMap<VehicleMake, VehicleMakeViewModel>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelViewModel>().ReverseMap();

            CreateMap<VehicleMakeDTO, VehicleMakeViewModel>().ReverseMap();
            CreateMap<VehicleModelDTO, VehicleModelViewModel>().ReverseMap();

            CreateMap<Filtering, IFiltering>().ReverseMap();
            CreateMap<Paging, IPaging>().ReverseMap();
            CreateMap<Sorting, ISorting>().ReverseMap();
        }
    }
}
