using VehicleManagementSystem.Model.Common;

namespace VehicleManagementSystem.Repository.Common;

public interface IUnitOfWork : IDisposable
{
   
    IVehicleMakeRepository VehicleMakeRepository { get; }
    IVehicleModelRepository VehicleModelRepository { get; }
    IVehicleEngineTypeRepository VehicleEngineTypeRepository { get; }
    IVehicleOwnerRepository VehicleOwnerRepository { get; }
    IVehicleRegistrationRepository VehicleRegistrationRepository { get; }
    
    Task<int> SaveChangesAsync();
} 