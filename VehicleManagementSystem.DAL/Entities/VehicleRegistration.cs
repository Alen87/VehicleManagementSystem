namespace VehicleManagementSystem.DAL.Entities;

/// <summary>
/// Predstavlja registraciju vozila
/// </summary>
public class VehicleRegistration
{
    /// <summary>
    /// Jedinstveni identifikator registracije
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Registracijski broj vozila
    /// </summary>
    public string RegistrationNumber { get; set; } = string.Empty;
    
    /// <summary>
    /// Strani ključ - ID modela vozila
    /// </summary>
    public int ModelId { get; set; }
    
    /// <summary>
    /// Strani ključ - ID vlasnika vozila
    /// </summary>
    public int OwnerId { get; set; }
    
    /// <summary>
    /// Strani ključ - ID specifične kombinacije modela i tipa motora
    /// </summary>
    public int ModelEngineTypeId { get; set; }
    
    /// <summary>
    /// Navigacijsko svojstvo - referenca na model vozila
    /// </summary>
    public virtual VehicleModel Model { get; set; } = null!;
    
    /// <summary>
    /// Navigacijsko svojstvo - referenca na vlasnika vozila
    /// </summary>
    public virtual VehicleOwner Owner { get; set; } = null!;
    
    /// <summary>
    /// Navigacijsko svojstvo - referenca na specifičnu kombinaciju modela i tipa motora
    /// </summary>
    public virtual VehicleModelEngineType ModelEngineType { get; set; } = null!;
} 