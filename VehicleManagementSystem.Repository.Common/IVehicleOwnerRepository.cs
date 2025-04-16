using VehicleManagementSystem.Model.Common;

namespace VehicleManagementSystem.Repository.Common;

/// <summary>
/// Sučelje za repozitorij vlasnika vozila
/// </summary>
public interface IVehicleOwnerRepository : IGenericRepository<IVehicleOwner>
{
    /// <summary>
    /// Dohvaća vlasnike prema imenu ili prezimenu
    /// </summary>
    /// <param name="searchTerm">Pojam za pretragu</param>
    /// <returns>Kolekcija vlasnika</returns>
    Task<IEnumerable<IVehicleOwner>> SearchByNameAsync(string searchTerm);
} 