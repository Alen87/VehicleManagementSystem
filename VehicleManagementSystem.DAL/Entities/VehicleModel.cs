namespace VehicleManagementSystem.DAL.Entities;

/// <summary>
/// Predstavlja model vozila (npr. 128, 325, X5 za BMW)
/// </summary>
public class VehicleModel
{
   
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abrv { get; set; } = string.Empty;
    public int MakeId { get; set; }                                 
    
   
    public virtual VehicleMake Make { get; set; } = null!;
} 