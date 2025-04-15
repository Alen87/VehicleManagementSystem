using System.Collections.Generic;
using VehicleManagementSystem.Common.Filtering;

namespace VehicleManagementSystem.Common.Paging;

/// <summary>
/// Osnovni zahtjev za straničenje podataka
/// </summary>
public class PagedRequest
{
    private const int MaxPageSize = 50;
    private int _pageSize = 10;
    
    /// <summary>
    /// Broj stranice (počinje od 1)
    /// </summary>
    public int PageNumber { get; set; } = 1;
    
    /// <summary>
    /// Veličina stranice (broj zapisa po stranici)
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    
    /// <summary>
    /// Naziv svojstva po kojem će se sortirati podaci
    /// </summary>
    public string? OrderBy { get; set; }
    
    /// <summary>
    /// Smjer sortiranja (asc - uzlazno, desc - silazno)
    /// </summary>
    public string SortDirection { get; set; } = "asc";
    
    /// <summary>
    /// Parametri za filtriranje
    /// </summary>
    public List<FilterParameter> Filters { get; set; } = new List<FilterParameter>();
} 