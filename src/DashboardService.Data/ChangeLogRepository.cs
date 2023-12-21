using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class ChangeLogRepository : IChangeLogRepository
{
  private readonly IDatabaseProvider _provider;

  public ChangeLogRepository(IDatabaseProvider provider)
  {
    _provider = provider;
  }

  public Task<Guid?> CreateAsync(DbChangeLog changeLog)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id, JsonPatchDocument<DbChangeLog> request)
  {
    throw new NotImplementedException();
  }

  public Task<DbChangeLog> GetAsync(Guid id, GetChangeLogFilter filter)
  {
    throw new NotImplementedException();
  }

  public Task<List<DbChangeLog>> GetChangeLogsAsync()
  {
    throw new NotImplementedException();
  }

  public Task<bool> RemoveAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}
