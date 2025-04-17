using System.Collections.Generic;
using VehicleManagementSystem.DAL;
using VehicleManagementSystem.Model.Common;
using VehicleManagementSystem.Repository.Common;

namespace VehicleManagementSystem.Repository;

/// <summary>
/// Implementacija Unit of Work obrasca koji upravlja transakcijama i repozitorijima
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly VehicleDbContext _context;
    private readonly Dictionary<Type, object> _repositories;
    private bool _disposed;

    private IVehicleMakeRepository _vehicleMakeRepository;
    private IVehicleModelRepository _vehicleModelRepository;
    private IVehicleEngineTypeRepository _vehicleEngineTypeRepository;
    private IVehicleOwnerRepository _vehicleOwnerRepository;
    private IVehicleRegistrationRepository _vehicleRegistrationRepository;

    /// <summary>
    /// Konstruktor koji inicijalizira UnitOfWork s DbContext-om
    /// </summary>
    /// <param name="context">DbContext za pristup bazi podataka</param>
    public UnitOfWork(VehicleDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
        _disposed = false;
    }

    /// <summary>
    /// Repozitorij za proizvođače vozila
    /// </summary>
    public IVehicleMakeRepository VehicleMakeRepository 
    {
        get 
        {
            if (_vehicleMakeRepository == null)
            {
                _vehicleMakeRepository = new VehicleMakeRepository(_context);
            }
            return _vehicleMakeRepository;
        }
    }

    /// <summary>
    /// Repozitorij za modele vozila
    /// </summary>
    public IVehicleModelRepository VehicleModelRepository 
    {
        get 
        {
            if (_vehicleModelRepository == null)
            {
                _vehicleModelRepository = new VehicleModelRepository(_context);
            }
            return _vehicleModelRepository;
        }
    }

    /// <summary>
    /// Repozitorij za tipove motora vozila
    /// </summary>
    public IVehicleEngineTypeRepository VehicleEngineTypeRepository 
    {
        get 
        {
            if (_vehicleEngineTypeRepository == null)
            {
                _vehicleEngineTypeRepository = new VehicleEngineTypeRepository(_context);
            }
            return _vehicleEngineTypeRepository;
        }
    }

    /// <summary>
    /// Repozitorij za vlasnike vozila
    /// </summary>
    public IVehicleOwnerRepository VehicleOwnerRepository 
    {
        get 
        {
            if (_vehicleOwnerRepository == null)
            {
                _vehicleOwnerRepository = new VehicleOwnerRepository(_context);
            }
            return _vehicleOwnerRepository;
        }
    }

    /// <summary>
    /// Repozitorij za registracije vozila
    /// </summary>
    public IVehicleRegistrationRepository VehicleRegistrationRepository 
    {
        get 
        {
            if (_vehicleRegistrationRepository == null)
            {
                _vehicleRegistrationRepository = new VehicleRegistrationRepository(_context);
            }
            return _vehicleRegistrationRepository;
        }
    }

    /// <summary>
    /// Dohvaća generički repozitorij za određeni tip entiteta
    /// </summary>
    public IGenericRepository<T> GetRepository<T>() where T : IBaseModel
    {
        // Provjera je li repozitorij već kreiran
        var type = typeof(T);
        if (_repositories.ContainsKey(type))
        {
            return (IGenericRepository<T>)_repositories[type];
        }

        // Ovdje trebamo kreirati odgovarajući repozitorij ovisno o tipu T
        // Ovo je pojednostavljeno - u stvarnoj implementaciji trebalo bi 
        // koristiti factory pattern ili dependency injection
        
        throw new NotImplementedException($"Repozitorij za tip {type.Name} nije implementiran.");
    }

    /// <summary>
    /// Sprema sve promjene u bazu podataka
    /// </summary>
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Oslobađa resurse
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Oslobađa resurse
    /// </summary>
    /// <param name="disposing">Oslobađa li se managed kod</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
} 