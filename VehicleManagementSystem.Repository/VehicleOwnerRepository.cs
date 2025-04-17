using VehicleManagementSystem.DAL;
using VehicleManagementSystem.DAL.Entities;
using VehicleManagementSystem.Model;
using VehicleManagementSystem.Model.Common;
using VehicleManagementSystem.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace VehicleManagementSystem.Repository;

public class VehicleOwnerRepository : GenericRepository<IVehicleOwner, VehicleOwner>, IVehicleOwnerRepository
{
    public VehicleOwnerRepository(VehicleDbContext context) : base(context)
    {
    }

    protected override IVehicleOwner MapEntityToModel(VehicleOwner entity)
    {
        return new Model.VehicleOwner
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            DOB = entity.DOB
        };
    }

    protected override VehicleOwner MapModelToEntity(IVehicleOwner model)
    {
        return new VehicleOwner
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            DOB = model.DOB
        };
    }

    protected override IQueryable<VehicleOwner> ApplyFiltering(IQueryable<VehicleOwner> query, Common.QueryOptions options)
    {
        // Implementacija filtriranja za VehicleOwner
        if (options.Filtering != null)
        {
            // Opći pretraživački upit
            if (!string.IsNullOrWhiteSpace(options.Filtering.SearchQuery))
            {
                string searchQuery = options.Filtering.SearchQuery.ToLower();
                query = query.Where(o => 
                    o.FirstName.ToLower().Contains(searchQuery) || 
                    o.LastName.ToLower().Contains(searchQuery));
            }
            
            // Filtriranje po FirstName
            if (options.Filtering.Filters.ContainsKey("firstName") && 
                !string.IsNullOrWhiteSpace(options.Filtering.Filters["firstName"]))
            {
                string firstName = options.Filtering.Filters["firstName"].ToLower();
                query = query.Where(o => o.FirstName.ToLower().Contains(firstName));
            }
            
            // Filtriranje po LastName
            if (options.Filtering.Filters.ContainsKey("lastName") && 
                !string.IsNullOrWhiteSpace(options.Filtering.Filters["lastName"]))
            {
                string lastName = options.Filtering.Filters["lastName"].ToLower();
                query = query.Where(o => o.LastName.ToLower().Contains(lastName));
            }
        }
        
        return query;
    }

    protected override IQueryable<VehicleOwner> ApplySorting(IQueryable<VehicleOwner> query, Common.QueryOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.Sorting.SortBy))
        {
            bool isAscending = options.Sorting.SortOrder.ToLower() == "asc";
            
            switch (options.Sorting.SortBy.ToLower())
            {
                case "firstname":
                    query = isAscending 
                        ? query.OrderBy(o => o.FirstName) 
                        : query.OrderByDescending(o => o.FirstName);
                    break;
                case "lastname":
                    query = isAscending 
                        ? query.OrderBy(o => o.LastName) 
                        : query.OrderByDescending(o => o.LastName);
                    break;
                case "dob":
                    query = isAscending 
                        ? query.OrderBy(o => o.DOB) 
                        : query.OrderByDescending(o => o.DOB);
                    break;
                default:
                    query = isAscending 
                        ? query.OrderBy(o => o.Id) 
                        : query.OrderByDescending(o => o.Id);
                    break;
            }
        }
        
        return query;
    }
} 