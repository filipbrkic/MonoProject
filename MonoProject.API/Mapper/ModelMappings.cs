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
            CreateMap<VehicleEngineType, VehicleEngineTypeDTO>().ReverseMap();
            CreateMap<VehicleOwner, VehicleOwnerDTO>().ReverseMap();
            CreateMap<VehicleRegistration, VehicleRegistrationDTO>().ReverseMap();
            CreateMap<VehicleModelToVehicleOwnerLink, VehicleModelToVehicleOwnerLinkDTO>().ReverseMap();

            CreateMap<VehicleModelToVehicleOwnerLinkDTO, VehicleOwnerDTO>().ReverseMap();

            CreateMap<Filtering, IFiltering>().ReverseMap();
            CreateMap<Paging, IPaging>().ReverseMap();
            CreateMap<Sorting, ISorting>().ReverseMap();
        }
    }
}
