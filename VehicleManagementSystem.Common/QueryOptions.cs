using VehicleManagementSystem.Common.Filtering;
using VehicleManagementSystem.Common.Paging;
using VehicleManagementSystem.Common.Sorting;

namespace VehicleManagementSystem.Common;

/// <summary>
/// Klasa koja kombinira opcije za filtriranje, sortiranje i stranice
/// </summary>
public class QueryOptions
{
    
    public FilterOptions Filtering { get; set; } = new FilterOptions();
    
    
    public SortOptions Sorting { get; set; } = new SortOptions();
    
   
    public PagingOptions Paging { get; set; } = new PagingOptions();
} 