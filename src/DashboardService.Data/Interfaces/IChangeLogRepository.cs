using LT.DigitalOffice.DashboardService.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface IChangeLogRepository
{
  Task<Guid?> CreateAsync(DbChangeLog board);

  Task<List<DbChangeLog>> GetChangeLogsAsync();

  Task<DbChangeLog> GetAsync(Guid id, GetChangeLogFilter filter);

  Task<bool> EditAsync(Guid id, JsonPatchDocument<DbChangeLog> request);

  Task<bool> RemoveAsync(Guid id);
}
