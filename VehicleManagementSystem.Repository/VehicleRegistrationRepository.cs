using VehicleManagementSystem.DAL;
using VehicleManagementSystem.DAL.Entities;
using VehicleManagementSystem.Model;
using VehicleManagementSystem.Model.Common;
using VehicleManagementSystem.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace VehicleManagementSystem.Repository;

public class VehicleRegistrationRepository : GenericRepository<IVehicleRegistration, VehicleRegistration>, IVehicleRegistrationRepository
{
    public VehicleRegistrationRepository(VehicleDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<IVehicleRegistration>> GetByOwnerIdAsync(int ownerId)
    {
        var entities = await _dbSet.Where(r => r.VehicleOwnerId == ownerId).ToListAsync();
        return entities.Select(MapEntityToModel);
    }

    public async Task<IEnumerable<IVehicleRegistration>> GetByModelIdAsync(int modelId)
    {
        var entities = await _dbSet.Where(r => r.VehicleModelId == modelId).ToListAsync();
        return entities.Select(MapEntityToModel);
    }

    protected override IVehicleRegistration MapEntityToModel(VehicleRegistration entity)
    {
        return new Model.VehicleRegistration
        {
            Id = entity.Id,
            RegistrationNumber = entity.RegistrationNumber,
            VehicleModelId = entity.VehicleModelId,
            VehicleModelEngineTypeId = entity.VehicleModelEngineTypeId,
            VehicleOwnerId = entity.VehicleOwnerId
        };
    }

    protected override VehicleRegistration MapModelToEntity(IVehicleRegistration model)
    {
        return new VehicleRegistration
        {
            Id = model.Id,
            RegistrationNumber = model.RegistrationNumber,
            VehicleModelId = model.VehicleModelId,
            VehicleModelEngineTypeId = model.VehicleModelEngineTypeId,
            VehicleOwnerId = model.VehicleOwnerId
        };
    }

    protected override IQueryable<VehicleRegistration> ApplyFiltering(IQueryable<VehicleRegistration> query, Common.QueryOptions options)
    {
        // Implementacija filtriranja za VehicleRegistration
        if (options.Filtering != null)
        {
            // Opći pretraživački upit
            if (!string.IsNullOrWhiteSpace(options.Filtering.SearchQuery))
            {
                string searchQuery = options.Filtering.SearchQuery.ToLower();
                query = query.Where(r => r.RegistrationNumber.ToLower().Contains(searchQuery));
            }
            
            // Filtriranje po VehicleModelId
            if (options.Filtering.Filters.ContainsKey("modelId") && 
                int.TryParse(options.Filtering.Filters["modelId"], out int modelId))
            {
                query = query.Where(r => r.VehicleModelId == modelId);
            }
            
            // Filtriranje po VehicleOwnerId
            if (options.Filtering.Filters.ContainsKey("ownerId") && 
                int.TryParse(options.Filtering.Filters["ownerId"], out int ownerId))
            {
                query = query.Where(r => r.VehicleOwnerId == ownerId);
            }

            // Filtriranje po VehicleModelEngineTypeId
            if (options.Filtering.Filters.ContainsKey("engineTypeId") && 
                int.TryParse(options.Filtering.Filters["engineTypeId"], out int engineTypeId))
            {
                query = query.Where(r => r.VehicleModelEngineTypeId == engineTypeId);
            }
        }
        
        return query;
    }

    protected override IQueryable<VehicleRegistration> ApplySorting(IQueryable<VehicleRegistration> query, Common.QueryOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.Sorting.SortBy))
        {
            bool isAscending = options.Sorting.SortOrder.ToLower() == "asc";
            
            switch (options.Sorting.SortBy.ToLower())
            {
                case "registrationnumber":
                    query = isAscending 
                        ? query.OrderBy(r => r.RegistrationNumber) 
                        : query.OrderByDescending(r => r.RegistrationNumber);
                    break;
                default:
                    query = isAscending 
                        ? query.OrderBy(r => r.Id) 
                        : query.OrderByDescending(r => r.Id);
                    break;
            }
        }
        
        return query;
    }
} 