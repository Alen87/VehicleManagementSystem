using VehicleManagementSystem.Common;
using VehicleManagementSystem.Common.Paging;
using VehicleManagementSystem.Model.Common;

namespace VehicleManagementSystem.Repository.Common;

/// <summary>
/// Sučelje za repozitorij modela vozila
/// </summary>
public interface IVehicleModelRepository : IGenericRepository<IVehicleModel>
{
    /// <summary>
    /// Dohvaća modele za određenog proizvođača
    /// </summary>
    /// <param name="makeId">ID proizvođača</param>
    /// <returns>Kolekcija modela</returns>
    Task<IEnumerable<IVehicleModel>> GetByMakeIdAsync(int makeId);
    
    /// <summary>
    /// Dohvaća straničene modele za određenog proizvođača
    /// </summary>
    /// <param name="makeId">ID proizvođača</param>
    /// <param name="queryOptions">Opcije za upit</param>
    /// <returns>Straničeni modeli</returns>
    Task<PagedResult<IVehicleModel>> GetPagedByMakeIdAsync(int makeId, QueryOptions queryOptions);
} 