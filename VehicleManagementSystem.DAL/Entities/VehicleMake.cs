namespace VehicleManagementSystem.DAL.Entities;

/// <summary>
/// Predstavlja proizvođača vozila (npr. BMW, Ford, Volkswagen)
/// </summary>
public class VehicleMake
{
    /// <summary>
    /// Jedinstveni identifikator proizvođača
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Naziv proizvođača vozila (npr. BMW, Ford)
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Skraćenica naziva proizvođača
    /// </summary>
    public string Abrv { get; set; } = string.Empty;
} 