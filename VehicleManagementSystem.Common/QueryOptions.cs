using VehicleManagementSystem.Common.Filtering;
using VehicleManagementSystem.Common.Paging;
using VehicleManagementSystem.Common.Sorting;

namespace VehicleManagementSystem.Common;

/// <summary>
/// Klasa koja kombinira opcije za filtriranje, sortiranje i straničenje
/// </summary>
public class QueryOptions
{
    /// <summary>
    /// Opcije za filtriranje
    /// </summary>
    public FilterOptions Filtering { get; set; } = new FilterOptions();
    
    /// <summary>
    /// Opcije za sortiranje
    /// </summary>
    public SortOptions Sorting { get; set; } = new SortOptions();
    
    /// <summary>
    /// Opcije za straničenje
    /// </summary>
    public PagingOptions Paging { get; set; } = new PagingOptions();
} 