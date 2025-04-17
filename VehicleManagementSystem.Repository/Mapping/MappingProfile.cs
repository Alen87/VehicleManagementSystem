using AutoMapper;
using VehicleManagementSystem.DAL.Entities;
using VehicleManagementSystem.Model;

namespace VehicleManagementSystem.Repository.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapiranje za VehicleMake
        CreateMap<VehicleMake, Model.VehicleMake>().ReverseMap();
        
        // Mapiranje za VehicleModel
        CreateMap<VehicleModel, Model.VehicleModel>().ReverseMap();
        
        // Mapiranje za VehicleEngineType
        CreateMap<VehicleEngineType, Model.VehicleEngineType>().ReverseMap();
        
        // Mapiranje za VehicleOwner
        CreateMap<VehicleOwner, Model.VehicleOwner>().ReverseMap();
        
        // Mapiranje za VehicleRegistration
        CreateMap<VehicleRegistration, Model.VehicleRegistration>().ReverseMap();
    }
} 