namespace VehicleManagementSystem.Common.Filtering;

/// <summary>
/// Klasa koja predstavlja jedan parametar za filtriranje
/// </summary>
public class FilterParameter
{
    /// <summary>
    /// Naziv svojstva po kojem filtriramo
    /// </summary>
    public string PropertyName { get; set; } = string.Empty;

    /// <summary>
    /// Vrijednost za filtriranje
    /// </summary>
    public string Value { get; set; } = string.Empty;
} 