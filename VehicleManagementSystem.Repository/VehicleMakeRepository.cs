using AutoMapper;
using VehicleManagementSystem.DAL;
using VehicleManagementSystem.DAL.Entities;
using VehicleManagementSystem.Model;
using VehicleManagementSystem.Model.Common;
using VehicleManagementSystem.Repository.Common;

namespace VehicleManagementSystem.Repository;


public class VehicleMakeRepository : GenericRepository<IVehicleMake, VehicleMake>, IVehicleMakeRepository
{
    public VehicleMakeRepository(VehicleDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
} 