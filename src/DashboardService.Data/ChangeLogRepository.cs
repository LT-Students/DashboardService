using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class ChangeLogRepository : IChangeLogRepository
{
  private readonly IDataProvider _provider;

  public ChangeLogRepository(IDataProvider provider)
  {
    _provider = provider;
  }

  public Task<Guid?> CreateAsync(DbChangeLog changeLog, CancellationToken ct)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id, JsonPatchDocument<DbChangeLog> request, CancellationToken ct)
  {
    throw new NotImplementedException();
  }

  public Task<DbChangeLog> GetAsync(Guid id, CancellationToken ct)
  {
    throw new NotImplementedException();
  }

  public Task<List<DbChangeLog>> GetChangeLogsAsync(GetChangeLogsFilter filter, CancellationToken ct)
  {
    throw new NotImplementedException();
  }

  public Task<bool> RemoveAsync(Guid id, CancellationToken ct)
  {
    throw new NotImplementedException();
  }
}
