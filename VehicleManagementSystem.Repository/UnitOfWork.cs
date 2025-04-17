using System.Collections.Generic;
using AutoMapper;
using VehicleManagementSystem.DAL;
using VehicleManagementSystem.Model.Common;
using VehicleManagementSystem.Repository.Common;

namespace VehicleManagementSystem.Repository;


public class UnitOfWork : IUnitOfWork
{
    private readonly VehicleDbContext _context;
    private readonly IMapper _mapper;
    private readonly Dictionary<Type, object> _repositories;
    private bool _disposed;

    private IVehicleMakeRepository _vehicleMakeRepository;
    private IVehicleModelRepository _vehicleModelRepository;
    private IVehicleEngineTypeRepository _vehicleEngineTypeRepository;
    private IVehicleOwnerRepository _vehicleOwnerRepository;
    private IVehicleRegistrationRepository _vehicleRegistrationRepository;

    
    public UnitOfWork(VehicleDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _repositories = new Dictionary<Type, object>();
        _disposed = false;
    }

   
    public IVehicleMakeRepository VehicleMakeRepository 
    {
        get 
        {
            if (_vehicleMakeRepository == null)
            {
                _vehicleMakeRepository = new VehicleMakeRepository(_context, _mapper);
            }
            return _vehicleMakeRepository;
        }
    }

    
    public IVehicleModelRepository VehicleModelRepository 
    {
        get 
        {
            if (_vehicleModelRepository == null)
            {
                _vehicleModelRepository = new VehicleModelRepository(_context, _mapper);
            }
            return _vehicleModelRepository;
        }
    }

   
    public IVehicleEngineTypeRepository VehicleEngineTypeRepository 
    {
        get 
        {
            if (_vehicleEngineTypeRepository == null)
            {
                _vehicleEngineTypeRepository = new VehicleEngineTypeRepository(_context, _mapper);
            }
            return _vehicleEngineTypeRepository;
        }
    }

  
    public IVehicleOwnerRepository VehicleOwnerRepository 
    {
        get 
        {
            if (_vehicleOwnerRepository == null)
            {
                _vehicleOwnerRepository = new VehicleOwnerRepository(_context, _mapper);
            }
            return _vehicleOwnerRepository;
        }
    }

    public IVehicleRegistrationRepository VehicleRegistrationRepository 
    {
        get 
        {
            if (_vehicleRegistrationRepository == null)
            {
                _vehicleRegistrationRepository = new VehicleRegistrationRepository(_context, _mapper);
            }
            return _vehicleRegistrationRepository;
        }
    }

   
    public IGenericRepository<T> GetRepository<T>() where T : IBaseModel
    {
       
        var type = typeof(T);
        if (_repositories.ContainsKey(type))
        {
            return (IGenericRepository<T>)_repositories[type];
        }

        
        throw new NotImplementedException($"Repozitorij za tip {type.Name} nije implementiran.");
    }

   
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    
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