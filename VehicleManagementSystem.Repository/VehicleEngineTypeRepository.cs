using AutoMapper;
using VehicleManagementSystem.DAL;
using VehicleManagementSystem.DAL.Entities;
using VehicleManagementSystem.Model;
using VehicleManagementSystem.Model.Common;
using VehicleManagementSystem.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace VehicleManagementSystem.Repository;

public class VehicleEngineTypeRepository : GenericRepository<IVehicleEngineType, VehicleEngineType>, IVehicleEngineTypeRepository
{
    public VehicleEngineTypeRepository(VehicleDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<VehicleEngineType> ApplyFiltering(IQueryable<VehicleEngineType> query, Common.QueryOptions options)
    {
       
        if (options.Filtering != null && !string.IsNullOrWhiteSpace(options.Filtering.SearchQuery))
        {
            string searchQuery = options.Filtering.SearchQuery.ToLower();
            query = query.Where(e => 
                e.Type.ToLower().Contains(searchQuery) || 
                e.Abrv.ToLower().Contains(searchQuery));
        }
        
        return query;
    }

    protected override IQueryable<VehicleEngineType> ApplySorting(IQueryable<VehicleEngineType> query, Common.QueryOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.Sorting.SortBy))
        {
            bool isAscending = options.Sorting.SortOrder.ToLower() == "asc";
            
            switch (options.Sorting.SortBy.ToLower())
            {
                case "type":
                    query = isAscending 
                        ? query.OrderBy(e => e.Type) 
                        : query.OrderByDescending(e => e.Type);
                    break;
                case "abrv":
                    query = isAscending 
                        ? query.OrderBy(e => e.Abrv) 
                        : query.OrderByDescending(e => e.Abrv);
                    break;
                default:
                    query = isAscending 
                        ? query.OrderBy(e => e.Id) 
                        : query.OrderByDescending(e => e.Id);
                    break;
            }
        }
        
        return query;
    }
} 