using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class TaskRepository : ITaskRepository
{
  private readonly IDataProvider _provider;

  public TaskRepository(IDataProvider provider)
  {
    _provider = provider;
  }
  
  public async Task<Guid> CreateAsync(DbTask dbTask)
  {
    _provider.Tasks.Add(dbTask);
    await _provider.SaveAsync();

    return dbTask.Id;
  }

  public async Task<(List<DbTask> dbTasks, int totalCount)> GetAllAsync(GetTasksFilter filter, CancellationToken ct)
  {
    IQueryable<DbTask> dbTasks = _provider.Tasks.AsNoTracking();

    if (filter.GroupId.HasValue)
    {
      dbTasks = dbTasks.Where(t => t.GroupId == filter.GroupId);
    }

    if (filter.BoardId.HasValue)
    {
      dbTasks = dbTasks
        .Include(t => t.Group)
        .Where(t => t.Group.BoardId == filter.BoardId);
    }
    
    if (filter.PriorityId.HasValue)
    {
      dbTasks = dbTasks.Where(t => t.PriorityId == filter.PriorityId);
    }
    
    if (filter.TaskTypeId.HasValue)
    {
      dbTasks = dbTasks.Where(t => t.TaskTypeId == filter.TaskTypeId);
    }
    
    if (filter.DeadlineAtUtc.HasValue)
    {
      dbTasks = dbTasks.Where(t => t.DeadlineAtUtc < filter.DeadlineAtUtc);
    }
    
    if (filter.CreatedBy.HasValue)
    {
      dbTasks = dbTasks.Where(t => t.CreatedBy == filter.CreatedBy);
    }

    if (filter.IsAscendingSort.HasValue)
    {
      dbTasks = filter.IsAscendingSort.Value
        ? dbTasks.OrderBy(d => d.Name)
        : dbTasks.OrderByDescending(d => d.Name);
    }

    if (!string.IsNullOrWhiteSpace(filter.NameIncludeSubstring))
    {
      dbTasks = dbTasks.Where(d => d.Name.Contains(filter.NameIncludeSubstring));
    }

    return (
      await dbTasks
        .Skip(filter.SkipCount)
        .Take(filter.TakeCount)
        .ToListAsync(ct),
      await dbTasks.CountAsync(ct));
  }

  public async Task<DbTask> GetAsync(Guid id, GetTaskFilter filter, CancellationToken ct)
  {
    return await IncludeRelatedEntities(filter, _provider.Tasks)
      .AsNoTracking()
      .FirstOrDefaultAsync(t => t.Id == id, ct);
  }

  public async Task<bool> EditAsync(Guid id, JsonPatchDocument<DbTask> request, CancellationToken ct)
  {
    DbTask dbTask = await _provider.Tasks.FindAsync(id);

    if (dbTask is null)
    {
      return false;
    }

    request.ApplyTo(dbTask);

    await _provider.SaveAsync();

    return true;
  }

  public async Task<bool> RemoveAsync(Guid id)
  {
    DbTask dbTask = await _provider.Tasks.FindAsync(id);

    if (dbTask is null)
    {
      return false;
    }

    _provider.Tasks.Remove(dbTask);
    await _provider.SaveAsync();

    return true;
  }

  private IQueryable<DbTask> IncludeRelatedEntities(GetTaskFilter filter, IQueryable<DbTask> dbTasks)
  {
    if (filter.IncludeTaskType)
    {
      dbTasks = dbTasks.Include(t => t.TaskType);
    }
    
    if (filter.IncludePriority)
    {
      dbTasks = dbTasks.Include(t => t.Priority);
    }

    if (filter.IncludeComments)
    {
      dbTasks = dbTasks.Include(t => t.Comments);
    }
    
    if (filter.IncludeLogs)
    {
      dbTasks = dbTasks.Include(t => t.Logs);
    }

    return dbTasks;
  }
}