using LT.DigitalOffice.DashboardService.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface IChangeLogRepository
{
  Task<Guid?> CreateAsync(DbChangeLog board, CancellationToken ct);

  Task<List<DbChangeLog>> GetChangeLogsAsync(GetChangeLogsFilter filter, CancellationToken ct);

  Task<DbChangeLog> GetAsync(Guid id, GetChangeLogFilter filter, CancellationToken ct);

  Task<bool> EditAsync(Guid id, JsonPatchDocument<DbChangeLog> request, CancellationToken ct);

  Task<bool> RemoveAsync(Guid id, CancellationToken ct);
}
