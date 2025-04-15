using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace VehicleManagementSystem.Common.Sorting;

/// <summary>
/// Proširenja za sortiranje kolekcija
/// </summary>
public static class SortingExtensions
{
    /// <summary>
    /// Sortira kolekciju prema zadanom polju i smjeru sortiranja
    /// </summary>
    /// <typeparam name="T">Tip podataka za sortiranje</typeparam>
    /// <param name="source">Izvor podataka za sortiranje</param>
    /// <param name="orderBy">Polje za sortiranje</param>
    /// <param name="sortDirection">Smjer sortiranja (asc ili desc)</param>
    /// <returns>Sortiran izvor podataka</returns>
    public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy, string sortDirection = "asc")
    {
        if (string.IsNullOrWhiteSpace(orderBy))
            return source;

        // Dobivamo sve svojstva tipa T
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        
        // Tražimo svojstvo s imenom identičnim orderBy parametru
        var property = properties.FirstOrDefault(p => 
            string.Equals(p.Name, orderBy, StringComparison.OrdinalIgnoreCase));
            
        // Ako svojstvo nije pronađeno, vrati nesortirane podatke
        if (property == null)
            return source;
        
        // Stvaramo parametar za lambda izraz (npr. 'x' u 'x => x.Name')
        var parameter = Expression.Parameter(typeof(T), "x");
        
        // Stvaramo pristup svojstvu (npr. 'x.Name')
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        
        // Stvaramo lambda izraz (npr. 'x => x.Name')
        var lambda = Expression.Lambda(propertyAccess, parameter);
        
        // Naziv metode za sortiranje
        string methodName = sortDirection.ToLower() == "asc" ? "OrderBy" : "OrderByDescending";
        
        // Tip povratne vrijednosti svojstva
        var resultType = property.PropertyType;
        
        // Generička metoda za sortiranje s tipom podataka i tipom svojstva
        var orderByMethod = typeof(Queryable).GetMethods()
            .First(m => m.Name == methodName && m.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), resultType);
        
        // Pozivamo metodu za sortiranje
        return (IQueryable<T>)orderByMethod.Invoke(null, new object[] { source, lambda })!;
    }
} 