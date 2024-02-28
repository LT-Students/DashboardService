using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface ITaskRepository
{
  Task<Guid> CreateAsync(DbTask dbTask);
  Task<(List<DbTask> dbTasks, int totalCount)> GetAllAsync(GetTasksFilter filter, CancellationToken ct);
  Task<DbTask> GetAsync(Guid id, GetTaskFilter filter, CancellationToken ct);
  Task<bool> EditAsync(Guid id, JsonPatchDocument<DbTask> request, CancellationToken ct);
  Task<bool> RemoveAsync(Guid id);
}