namespace VehicleManagementSystem.DAL.Entities;

/// <summary>
/// Predstavlja model vozila (npr. 128, 325, X5 za BMW)
/// </summary>
public class VehicleModel
{
    /// <summary>
    /// Jedinstveni identifikator modela
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Naziv modela vozila
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Skraćenica naziva modela
    /// </summary>
    public string Abrv { get; set; } = string.Empty;
    
    /// <summary>
    /// Strani ključ - ID proizvođača vozila
    /// </summary>
    public int MakeId { get; set; }
    
    /// <summary>
    /// Navigacijsko svojstvo - referenca na proizvođača vozila
    /// </summary>
    public virtual VehicleMake Make { get; set; } = null!;
    
    /// <summary>
    /// Navigacijsko svojstvo - kolekcija registracija za ovaj model
    /// </summary>
    public virtual ICollection<VehicleRegistration> Registrations { get; set; } = new List<VehicleRegistration>();
    
    /// <summary>
    /// Navigacijsko svojstvo - veza više-na-više s tipovima motora kroz spojnu tablicu
    /// </summary>
    public virtual ICollection<VehicleModelEngineType> ModelEngineTypes { get; set; } = new List<VehicleModelEngineType>();
} 