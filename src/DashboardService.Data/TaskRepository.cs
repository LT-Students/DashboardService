using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class TaskRepository : ITaskRepository
{
  private readonly IDataProvider _provider;

  public TaskRepository(IDataProvider provider)
  {
    _provider = provider;
  }
  
  public Task<Guid?> CreateAsync(DbTask dbDepartment)
  {
    throw new NotImplementedException();
  }

  public Task<List<DbTask>> GetAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<DbTask> GetAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> RemoveAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}