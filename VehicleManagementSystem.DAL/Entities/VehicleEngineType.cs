namespace VehicleManagementSystem.DAL.Entities;

/// <summary>
/// Predstavlja tip motora vozila (npr. Diesel, Benzin, Električni)
/// </summary>
public class VehicleEngineType
{
    /// <summary>
    /// Jedinstveni identifikator tipa motora
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Naziv tipa motora
    /// </summary>
    public string Type { get; set; } = string.Empty;
    
    /// <summary>
    /// Skraćenica naziva tipa motora
    /// </summary>
    public string Abrv { get; set; } = string.Empty;
    
    /// <summary>
    /// Navigacijsko svojstvo - veza više-na-više s modelima vozila kroz spojnu tablicu
    /// </summary>
    public virtual ICollection<VehicleModelEngineType> ModelEngineTypes { get; set; } = new List<VehicleModelEngineType>();
} 