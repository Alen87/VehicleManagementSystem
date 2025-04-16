using VehicleManagementSystem.Model.Common;

namespace VehicleManagementSystem.Model;

/// <summary>
/// Model koji predstavlja proizvođača vozila (npr. BMW, Ford, Volkswagen)
/// </summary>
public class VehicleMake : IVehicleMake
{
    /// <summary>
    /// Jedinstveni identifikator proizvođača
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Naziv proizvođača
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Skraćenica naziva proizvođača
    /// </summary>
    public string Abrv { get; set; } = string.Empty;
} 