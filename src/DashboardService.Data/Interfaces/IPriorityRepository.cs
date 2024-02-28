using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface IPriorityRepository
{
  Task<Guid?> CreateAsync(DbPriority dbPriority);
  Task<(List<DbPriority> dbPriorities, int totalCount)> GetAllAsync(GetPrioritiesFilter filter, CancellationToken ct);
  Task<DbPriority> GetAsync(Guid id, CancellationToken ct);
  Task<bool> EditAsync(Guid id, JsonPatchDocument<DbPriority> request, CancellationToken ct);
  Task<bool> RemoveAsync(Guid id, CancellationToken ct);
  Task<bool> NameExistAsync(string name, CancellationToken ct, Guid? priorityId = default);
  Task<bool> ExistAsync(Guid id, CancellationToken ct);
}