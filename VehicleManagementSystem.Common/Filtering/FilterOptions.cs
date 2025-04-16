namespace VehicleManagementSystem.Common.Filtering;

/// <summary>
/// Klasa koja sadrži opcije za filtriranje
/// </summary>
public class FilterOptions
{
   
    public string? SearchText { get; set; }
    
    
    public string? SearchField { get; set; }
    
    public int? MakeId { get; set; }
    
    public int? ModelId { get; set; }
} 