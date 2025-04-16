using VehicleManagementSystem.Model.Common;

namespace VehicleManagementSystem.Model;

/// <summary>
/// Model koji predstavlja vlasnika vozila
/// </summary>
public class VehicleOwner : IVehicleOwner
{
   
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DOB { get; set; }
    
} 