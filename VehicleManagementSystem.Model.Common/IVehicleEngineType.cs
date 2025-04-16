namespace VehicleManagementSystem.Model.Common;

/// <summary>
/// Sučelje za tip motora vozila
/// </summary>
public interface IVehicleEngineType : IBaseModel
{
    
    string Type { get; set; }
    string Abrv { get; set; }
} 