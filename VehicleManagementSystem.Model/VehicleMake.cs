using VehicleManagementSystem.Model.Common;

namespace VehicleManagementSystem.Model;

/// <summary>
/// Model koji predstavlja proizvođača vozila 
/// </summary>
public class VehicleMake : IVehicleMake
{
    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abrv { get; set; } = string.Empty;
} 