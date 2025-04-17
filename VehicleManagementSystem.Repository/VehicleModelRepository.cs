using VehicleManagementSystem.DAL;
using VehicleManagementSystem.DAL.Entities;
using VehicleManagementSystem.Model;
using VehicleManagementSystem.Model.Common;
using VehicleManagementSystem.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace VehicleManagementSystem.Repository;

public class VehicleModelRepository : GenericRepository<IVehicleModel, VehicleModel>, IVehicleModelRepository
{
    public VehicleModelRepository(VehicleDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<IVehicleModel>> GetByMakeIdAsync(int makeId)
    {
        var entities = await _dbSet.Where(m => m.VehicleMakeId == makeId).ToListAsync();
        return entities.Select(MapEntityToModel);
    }

    protected override IVehicleModel MapEntityToModel(VehicleModel entity)
    {
        return new Model.VehicleModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Abrv = entity.Abrv,
            VehicleMakeId = entity.VehicleMakeId
        };
    }

    protected override VehicleModel MapModelToEntity(IVehicleModel model)
    {
        return new VehicleModel
        {
            Id = model.Id,
            Name = model.Name,
            Abrv = model.Abrv,
            VehicleMakeId = model.VehicleMakeId
        };
    }

    protected override IQueryable<VehicleModel> ApplyFiltering(IQueryable<VehicleModel> query, Common.QueryOptions options)
    {
        // Implementacija filtriranja za VehicleModel
        if (options.Filtering != null && !string.IsNullOrWhiteSpace(options.Filtering.SearchQuery))
        {
            string searchQuery = options.Filtering.SearchQuery.ToLower();
            query = query.Where(m => 
                m.Name.ToLower().Contains(searchQuery) || 
                m.Abrv.ToLower().Contains(searchQuery));
        }

        // Filtriranje po MakeId ako je specificirano
        if (options.Filtering != null && options.Filtering.Filters.ContainsKey("makeId"))
        {
            if (int.TryParse(options.Filtering.Filters["makeId"], out int makeId))
            {
                query = query.Where(m => m.VehicleMakeId == makeId);
            }
        }

        return query;
    }

    protected override IQueryable<VehicleModel> ApplySorting(IQueryable<VehicleModel> query, Common.QueryOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.Sorting.SortBy))
        {
            bool isAscending = options.Sorting.SortOrder.ToLower() == "asc";
            
            switch (options.Sorting.SortBy.ToLower())
            {
                case "name":
                    query = isAscending 
                        ? query.OrderBy(m => m.Name) 
                        : query.OrderByDescending(m => m.Name);
                    break;
                case "abrv":
                    query = isAscending 
                        ? query.OrderBy(m => m.Abrv) 
                        : query.OrderByDescending(m => m.Abrv);
                    break;
                default: // Po defaultu sortiramo po ID-u
                    query = isAscending 
                        ? query.OrderBy(m => m.Id) 
                        : query.OrderByDescending(m => m.Id);
                    break;
            }
        }
        
        return query;
    }
} 