namespace VehicleManagementSystem.Common.Paging;

/// <summary>
/// Klasa koja predstavlja stranicu podataka s informacijama o paginaciji
/// </summary>

public class PagedList<T>
{
   
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    public List<T> Items { get; set; } = new List<T>();
    
    public PagedList()
    {
    }
    
    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        Items = items;
    }
} 