using VehicleManagementSystem.Model.Common;

namespace VehicleManagementSystem.Model;

/// <summary>
/// Model koji predstavlja tip motora vozila 
/// </summary>
public class VehicleEngineType : IVehicleEngineType
{
    
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Abrv { get; set; } = string.Empty;
} 