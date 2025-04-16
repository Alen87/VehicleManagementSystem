using VehicleManagementSystem.Common;
using VehicleManagementSystem.Common.Paging;
using VehicleManagementSystem.Model.Common;

namespace VehicleManagementSystem.Repository.Common;

/// <summary>
/// Sučelje za repozitorij registracija vozila
/// </summary>
public interface IVehicleRegistrationRepository : IGenericRepository<IVehicleRegistration>
{
    /// <summary>
    /// Dohvaća registracije za određenog vlasnika
    /// </summary>
    /// <param name="ownerId">ID vlasnika</param>
    /// <returns>Kolekcija registracija</returns>
    Task<IEnumerable<IVehicleRegistration>> GetByOwnerIdAsync(int ownerId);
    
    /// <summary>
    /// Dohvaća registracije za određeni model
    /// </summary>
    /// <param name="modelId">ID modela</param>
    /// <returns>Kolekcija registracija</returns>
    Task<IEnumerable<IVehicleRegistration>> GetByModelIdAsync(int modelId);
    
    /// <summary>
    /// Dohvaća straničene registracije za određenog vlasnika
    /// </summary>
    /// <param name="ownerId">ID vlasnika</param>
    /// <param name="queryOptions">Opcije za upit</param>
    /// <returns>Straničene registracije</returns>
    Task<PagedResult<IVehicleRegistration>> GetPagedByOwnerIdAsync(int ownerId, QueryOptions queryOptions);
    
    /// <summary>
    /// Dohvaća registraciju prema registracijskom broju
    /// </summary>
    /// <param name="registrationNumber">Registracijski broj</param>
    /// <returns>Registracija ako postoji, inače null</returns>
    Task<IVehicleRegistration?> GetByRegistrationNumberAsync(string registrationNumber);
} 