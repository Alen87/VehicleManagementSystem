namespace VehicleManagementSystem.Model.Common;

/// <summary>
/// Sučelje za model vozila
/// </summary>
public interface IVehicleModel : IBaseModel
{
  
    string Name { get; set; }
    string Abrv { get; set; }
    int MakeId { get; set; }
    string MakeName { get; set; }
} 