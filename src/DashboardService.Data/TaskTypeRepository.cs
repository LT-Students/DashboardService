using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType.Filters;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class TaskTypeRepository : ITaskTypeRepository
{
  private readonly IDataProvider _provider;

  public TaskTypeRepository(IDataProvider provider)
  {
    _provider = provider;
  }
  
  public Task<Guid?> CreateAsync(DbTaskType dbDepartment)
  {
    throw new NotImplementedException();
  }

  public Task<List<DbTaskType>> GetAllAsync(GetTaskTypesFilter filter)
  {
    throw new NotImplementedException();
  }

  public Task<DbTaskType> GetAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id, JsonPatchDocument<DbTaskType> request)
  {
    throw new NotImplementedException();
  }

  public Task<bool> RemoveAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}