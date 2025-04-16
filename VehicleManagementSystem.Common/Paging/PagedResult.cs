namespace VehicleManagementSystem.Common.Paging;

/// <summary>
/// Klasa koja predstavlja rezultat straničenja
/// </summary>
/// <typeparam name="T">Tip podataka</typeparam>
public class PagedResult<T>
{
    /// <summary>
    /// Trenutna stranica
    /// </summary>
    public int CurrentPage { get; set; }
    
    /// <summary>
    /// Ukupan broj stranica
    /// </summary>
    public int TotalPages { get; set; }
    
    /// <summary>
    /// Veličina stranice
    /// </summary>
    public int PageSize { get; set; }
    
    /// <summary>
    /// Ukupan broj zapisa
    /// </summary>
    public int TotalCount { get; set; }
    
    /// <summary>
    /// Podaci na stranici
    /// </summary>
    public List<T> Data { get; set; } = new List<T>();
    
    /// <summary>
    /// Ima li prethodna stranica
    /// </summary>
    public bool HasPrevious => CurrentPage > 1;
    
    /// <summary>
    /// Ima li sljedeća stranica
    /// </summary>
    public bool HasNext => CurrentPage < TotalPages;
    
    /// <summary>
    /// Stvara novu instancu PagedResult klase
    /// </summary>
    public PagedResult()
    {
    }
    
    /// <summary>
    /// Stvara novu instancu PagedResult klase s podacima
    /// </summary>
    public PagedResult(List<T> data, int totalCount, int pageNumber, int pageSize)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    }
} 