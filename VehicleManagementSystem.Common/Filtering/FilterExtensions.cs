using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace VehicleManagementSystem.Common.Filtering;

/// <summary>
/// Proširenja za filtriranje kolekcija
/// </summary>
public static class FilterExtensions
{
    /// <summary>
    /// Primjenjuje filtriranje na kolekciju prema zadanom filtru
    /// </summary>
    /// <typeparam name="T">Tip podataka za filtriranje</typeparam>
    /// <param name="source">Izvor podataka za filtriranje</param>
    /// <param name="parameter">Parametar za filtriranje</param>
    /// <returns>Filtrirani izvor podataka</returns>
    public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> source, FilterParameter parameter)
    {
        if (string.IsNullOrWhiteSpace(parameter.PropertyName) || string.IsNullOrWhiteSpace(parameter.Value))
            return source;

        // Dobivamo sve svojstva tipa T
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        
        // Tražimo svojstvo s imenom identičnim PropertyName parametru
        var property = properties.FirstOrDefault(p => 
            string.Equals(p.Name, parameter.PropertyName, StringComparison.OrdinalIgnoreCase));
            
        // Ako svojstvo nije pronađeno, vrati nefiltrirane podatke
        if (property == null)
            return source;

        // Stvaramo parametar za lambda izraz (npr. 'x' u 'x => x.Name.Contains("value")')
        var parameter1 = Expression.Parameter(typeof(T), "x");
        
        // Stvaramo pristup svojstvu (npr. 'x.Name')
        var propertyAccess = Expression.MakeMemberAccess(parameter1, property);

        // Stvaramo izraz za usporedbu ovisno o tipu svojstva
        Expression? comparison = null;

        if (property.PropertyType == typeof(string))
        {
            // Za string koristimo Contains metodu
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            if (containsMethod != null)
            {
                // Stvaramo poziv metode x.Property.Contains("value")
                comparison = Expression.Call(
                    propertyAccess,
                    containsMethod,
                    Expression.Constant(parameter.Value)
                );
            }
        }
        else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
        {
            // Za brojeve pokušavamo parsirati vrijednost i usporediti
            if (int.TryParse(parameter.Value, out int intValue))
            {
                // Stvaramo izraz x.Property == intValue
                comparison = Expression.Equal(
                    propertyAccess,
                    Expression.Constant(intValue, property.PropertyType)
                );
            }
        }
        
        // Ako nismo uspjeli stvoriti izraz za usporedbu, vrati nefiltrirane podatke
        if (comparison == null)
            return source;
        
        // Stvaramo lambda izraz (npr. 'x => x.Name.Contains("value")')
        var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter1);
        
        // Primjenjujemo filtar na izvor podataka
        return source.Where(lambda);
    }
} 