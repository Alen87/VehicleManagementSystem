using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VehicleManagementSystem.Common;
using VehicleManagementSystem.Common.Paging;
using VehicleManagementSystem.Common.Sorting;
using VehicleManagementSystem.DAL;
using VehicleManagementSystem.Model.Common;
using VehicleManagementSystem.Repository.Common;

namespace VehicleManagementSystem.Repository;

/// <summary>
/// Generička implementacija repozitorija koja pruža osnovne CRUD operacije
/// </summary>
/// <typeparam name="T">Tip modela</typeparam>
/// <typeparam name="TEntity">Tip entiteta</typeparam>
public class GenericRepository<T, TEntity> : IGenericRepository<T> 
    where T : class, IBaseModel 
    where TEntity : class
{
    protected readonly VehicleDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    /// <summary>
    /// Konstruktor koji inicijalizira repozitorij s DbContext-om
    /// </summary>
    /// <param name="context">DbContext za pristup bazi podataka</param>
    public GenericRepository(VehicleDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    /// <summary>
    /// Dohvaća sve entitete
    /// </summary>
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(MapEntityToModel);
    }

    /// <summary>
    /// Dohvaća entitete s opcijama za filtriranje, sortiranje i straničenje
    /// </summary>
    public virtual async Task<PagedResult<T>> GetPagedAsync(QueryOptions queryOptions)
    {
        // Početni upit
        IQueryable<TEntity> query = _dbSet;
        
        // Primjena filtriranja
        query = ApplyFiltering(query, queryOptions);
        
        // Brojanje ukupnih rezultata nakon filtriranja, ali prije paginacije
        var totalCount = await query.CountAsync();
        
        // Primjena sortiranja
        if (!string.IsNullOrWhiteSpace(queryOptions.Sorting.SortBy))
        {
            query = ApplySorting(query, queryOptions);
        }
        
        // Primjena paginacije
        query = query.Skip((queryOptions.Paging.PageNumber - 1) * queryOptions.Paging.PageSize)
                     .Take(queryOptions.Paging.PageSize);
        
        // Izvršavanje upita i mapiranje rezultata
        var items = await query.ToListAsync();
        var mappedItems = items.Select(MapEntityToModel).ToList();
        
        // Kreiranje rezultata paginacije
        return new PagedResult<T>(
            mappedItems, 
            totalCount, 
            queryOptions.Paging.PageNumber, 
            queryOptions.Paging.PageSize);
    }

    /// <summary>
    /// Dohvaća entitet prema ID-u
    /// </summary>
    public virtual async Task<T?> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity != null ? MapEntityToModel(entity) : default;
    }

    /// <summary>
    /// Dohvaća prvi entitet koji zadovoljava uvjet
    /// </summary>
    public virtual async Task<T?> GetFirstAsync(Expression<Func<T, bool>> predicate)
    {
        // Ovo je pojednostavljeno - u stvarnoj implementaciji potrebno je 
        // konvertirati Expression<Func<T, bool>> u Expression<Func<TEntity, bool>>
        // što zahtijeva kompleksniju logiku
        
        // Za demonstraciju, dohvaćamo sve i filtriramo u memoriji
        var entities = await _dbSet.ToListAsync();
        var models = entities.Select(MapEntityToModel);
        return models.FirstOrDefault(predicate.Compile());
    }

    /// <summary>
    /// Dodaje novi entitet
    /// </summary>
    public virtual async Task<T> AddAsync(T entity)
    {
        var entityToAdd = MapModelToEntity(entity);
        var result = await _dbSet.AddAsync(entityToAdd);
        await _context.SaveChangesAsync();
        
        return MapEntityToModel(result.Entity);
    }

    /// <summary>
    /// Ažurira postojeći entitet
    /// </summary>
    public virtual async Task<T> UpdateAsync(T entity)
    {
        var entityToUpdate = MapModelToEntity(entity);
        
        // Attach ako nije praćen
        _context.Entry(entityToUpdate).State = EntityState.Modified;
        
        await _context.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Briše entitet prema ID-u
    /// </summary>
    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;
        
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Provjerava postoji li entitet koji zadovoljava uvjet
    /// </summary>
    public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        // Isto kao i kod GetFirstAsync, ovo je pojednostavljeno
        var entities = await _dbSet.ToListAsync();
        var models = entities.Select(MapEntityToModel);
        return models.Any(predicate.Compile());
    }

    /// <summary>
    /// Mapira entitet u model
    /// </summary>
    protected virtual T MapEntityToModel(TEntity entity)
    {
        // Ova metoda treba biti prepisana u izvedenim klasama
        throw new NotImplementedException("MapEntityToModel mora biti implementiran u izvedenoj klasi.");
    }

    /// <summary>
    /// Mapira model u entitet
    /// </summary>
    protected virtual TEntity MapModelToEntity(T model)
    {
        // Ova metoda treba biti prepisana u izvedenim klasama
        throw new NotImplementedException("MapModelToEntity mora biti implementiran u izvedenoj klasi.");
    }
    
    /// <summary>
    /// Primjenjuje filtriranje na upit
    /// </summary>
    protected virtual IQueryable<TEntity> ApplyFiltering(IQueryable<TEntity> query, QueryOptions options)
    {
        // Ovo je pojednostavljeno - u stvarnoj implementaciji trebalo bi 
        // implementirati filtriranje na razini baze podataka
        // Ova metoda treba biti prepisana u izvedenim klasama
        return query;
    }
    
    /// <summary>
    /// Primjenjuje sortiranje na upit
    /// </summary>
    protected virtual IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, QueryOptions options)
    {
        // Ovo je pojednostavljeno - u stvarnoj implementaciji trebalo bi 
        // implementirati sortiranje na razini baze podataka
        // Ova metoda treba biti prepisana u izvedenim klasama
        return query;
    }
} 