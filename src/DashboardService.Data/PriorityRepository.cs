using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class PriorityRepository : IPriorityRepository
{
  private readonly IDataProvider _provider;

  public PriorityRepository([FromServices] IDataProvider provider)
  {
    _provider = provider;
  }
  
  public Task<Guid?> CreateAsync(DbPriority dbDepartment)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<DbPriority>> GetAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<DbPriority> GetAsync(Guid id)
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