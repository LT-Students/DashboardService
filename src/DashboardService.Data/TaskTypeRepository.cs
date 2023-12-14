using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class TaskTypeRepository : ITaskTypeRepository
{
  public Task<Guid?> CreateAsync(DbTaskType dbDepartment)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<DbTaskType>> GetAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<DbTaskType> GetAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> DeleteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}