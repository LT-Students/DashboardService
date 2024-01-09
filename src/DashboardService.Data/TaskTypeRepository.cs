using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType.Filters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class TaskTypeRepository : ITaskTypeRepository
{
  private readonly IDataProvider _provider;

  public TaskTypeRepository(IDataProvider provider)
  {
    _provider = provider;
  }
  
  public async Task<Guid?> CreateAsync(DbTaskType dbTaskType)
  {
    _provider.TaskTypes.Add(dbTaskType);
    await _provider.SaveAsync();

    return dbTaskType.Id;
  }

  public async Task<(List<DbTaskType> dbTaskTypes, int totalCount)> GetAllAsync(GetTaskTypesFilter filter, CancellationToken ct)
  {
    IQueryable<DbTaskType> taskTypes = _provider.TaskTypes.AsNoTracking();

    if (filter.IsAscendingSort.HasValue)
    {
      taskTypes = filter.IsAscendingSort.Value
        ? taskTypes.OrderBy(d => d.Name)
        : taskTypes.OrderByDescending(d => d.Name);
    }

    if (!string.IsNullOrWhiteSpace(filter.NameIncludeSubstring))
    {
      taskTypes = taskTypes.Where(d => d.Name.Contains(filter.NameIncludeSubstring));
    }

    return (
      await taskTypes
        .Skip(filter.SkipCount)
        .Take(filter.TakeCount)
        .ToListAsync(ct),
      await taskTypes.CountAsync(ct));
  }

  public async Task<DbTaskType> GetAsync(Guid id, CancellationToken ct)
  {
    return await _provider.TaskTypes.AsNoTracking().FirstOrDefaultAsync(tt => tt.Id == id, ct);
  }

  public async Task<bool> EditAsync(Guid id, JsonPatchDocument<DbTaskType> request, CancellationToken ct)
  {
    DbTaskType dbTaskType = await _provider.TaskTypes.FindAsync(id, ct);

    if (dbTaskType is null)
    {
      return false;
    }

    request.ApplyTo(dbTaskType);

    await _provider.SaveAsync();

    return true;
  }

  public async Task<bool> RemoveAsync(Guid id, CancellationToken ct)
  {
    DbTaskType dbTaskType = await GetAsync(id, ct);

    if (dbTaskType is null)
    {
      return false;
    }

    _provider.TaskTypes.Remove(dbTaskType);
    await _provider.SaveAsync();

    return true;
  }

  public Task<bool> NameExistAsync(string name, CancellationToken ct, Guid? taskTypeId = default)
  {
    return taskTypeId.HasValue
      ? _provider.TaskTypes.AnyAsync(d => d.Name == name && d.Id != taskTypeId, ct)
      : _provider.TaskTypes.AnyAsync(d => d.Name == name, ct);
  }
}