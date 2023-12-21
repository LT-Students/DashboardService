using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority.Filters;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class PriorityRepository : IPriorityRepository
{
  private readonly IDataProvider _provider;

  public PriorityRepository(IDataProvider provider)
  {
    _provider = provider;
  }
  
  public Task<Guid?> CreateAsync(DbPriority dbDepartment)
  {
    throw new NotImplementedException();
  }

  public Task<List<DbPriority>> GetAllAsync(GetPrioritiesFilter filter)
  {
    throw new NotImplementedException();
  }

  public Task<DbPriority> GetAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id, JsonPatchDocument<DbPriority> request)
  {
    throw new NotImplementedException();
  }

  public Task<bool> RemoveAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}