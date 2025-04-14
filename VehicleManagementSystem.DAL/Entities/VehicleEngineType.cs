namespace VehicleManagementSystem.DAL.Entities;

/// <summary>
/// Predstavlja tip motora vozila (npr. Diesel, Benzin, Električni)
/// </summary>
public class VehicleEngineType
{
  
    public int Id { get; set; }
    
    public string Type { get; set; } = string.Empty;
    public string Abrv { get; set; } = string.Empty;
} 