using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface ITaskTypeRepository
{
  Task<Guid?> CreateAsync(DbTaskType dbDepartment);
  Task<(List<DbTaskType> dbTaskTypes, int totalCount)> GetAllAsync(GetTaskTypesFilter filter, CancellationToken ct);
  Task<DbTaskType> GetAsync(Guid id, CancellationToken ct);
  Task<bool> EditAsync(Guid id, JsonPatchDocument<DbTaskType> request, CancellationToken ct);
  Task<bool> RemoveAsync(Guid id, CancellationToken ct);
  Task<bool> NameExistAsync(string name, CancellationToken ct, Guid? priorityId = default);
}