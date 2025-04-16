namespace VehicleManagementSystem.Common.Sorting;

/// <summary>
/// Klasa koja sadrži opcije za sortiranje
/// </summary>
public class SortOptions
{
    /// <summary>
    /// Polje po kojem će se sortirati
    /// </summary>
    public string? SortBy { get; set; }
    
    /// <summary>
    /// Smjer sortiranja (true = uzlazno, false = silazno)
    /// </summary>
    public bool SortAscending { get; set; } = true;
} 