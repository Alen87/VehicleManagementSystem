namespace VehicleManagementSystem.DAL.Entities;

/// <summary>
/// Predstavlja vlasnika vozila
/// </summary>
public class VehicleOwner
{

    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DOB { get; set; }
} 