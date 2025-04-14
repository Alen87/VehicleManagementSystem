namespace VehicleManagementSystem.DAL.Entities;

/// <summary>
/// Predstavlja registraciju vozila
/// </summary>
public class VehicleRegistration
{
  
    public int Id { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public int ModelId { get; set; }
    public int OwnerId { get; set; }
    public int EngineTypeId { get; set; }
    
    
    public virtual VehicleModel Model { get; set; } = null!;
    public virtual VehicleOwner Owner { get; set; } = null!;
    public virtual VehicleEngineType EngineType { get; set; } = null!;
} 