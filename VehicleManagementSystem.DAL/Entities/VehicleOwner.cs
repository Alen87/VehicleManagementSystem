namespace VehicleManagementSystem.DAL.Entities;


public class VehicleOwner
{
    /// <summary>
    /// Jedinstveni identifikator vlasnika
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Ime vlasnika
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    
    /// <summary>
    /// Prezime vlasnika
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>
    /// Datum rođenja vlasnika
    /// </summary>
    public DateTime DOB { get; set; }
    
    /// <summary>
    /// Navigacijsko svojstvo - kolekcija registracija za ovog vlasnika
    /// </summary>
    public virtual ICollection<VehicleRegistration> Registrations { get; set; } = new List<VehicleRegistration>();
} 