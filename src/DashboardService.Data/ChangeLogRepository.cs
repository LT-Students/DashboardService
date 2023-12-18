using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class ChangeLogRepository : IChangeLogRepository
{
  private readonly IDatabaseProvider _provider;

  public ChangeLogRepository(
    [FromServices] IDatabaseProvider provider)
  {
    _provider = provider;
  }

  public Task<Guid?> CreateAsync(DbChangeLog changeLog)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<DbChangeLog> GetAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<DbChangeLog>> GetAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<bool> RemoveAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<DbTask>> GetTasksAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}
