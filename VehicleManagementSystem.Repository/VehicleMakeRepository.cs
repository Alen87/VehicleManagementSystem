using VehicleManagementSystem.DAL;
using VehicleManagementSystem.DAL.Entities;
using VehicleManagementSystem.Model;
using VehicleManagementSystem.Model.Common;
using VehicleManagementSystem.Repository.Common;

namespace VehicleManagementSystem.Repository;

/// <summary>
/// Repozitorij za proizvođače vozila
/// </summary>
public class VehicleMakeRepository : GenericRepository<IVehicleMake, VehicleMake>, IVehicleMakeRepository
{
    /// <summary>
    /// Konstruktor koji inicijalizira repozitorij s DbContext-om
    /// </summary>
    /// <param name="context">DbContext za pristup bazi podataka</param>
    public VehicleMakeRepository(VehicleDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Mapira entitet iz baze u model
    /// </summary>
    protected override IVehicleMake MapEntityToModel(VehicleMake entity)
    {
        return new Model.VehicleMake
        {
            Id = entity.Id,
            Name = entity.Name,
            Abrv = entity.Abrv
        };
    }

    /// <summary>
    /// Mapira model u entitet za bazu
    /// </summary>
    protected override VehicleMake MapModelToEntity(IVehicleMake model)
    {
        return new VehicleMake
        {
            Id = model.Id,
            Name = model.Name,
            Abrv = model.Abrv
        };
    }
} 