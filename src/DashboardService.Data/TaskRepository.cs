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

  public async Task<(List<DbTask> dbTasks, int totalCount)> GetAllAsync(GetTasksFilter filter, CancellationToken cancellationToken)
  {
    // TODO: Wait for groups implementation
    //IQueryable<DbTask> dbTasks = _provider.Tasks.Where(t => t.GroupId == filter.GroupId).AsNoTracking();
    IQueryable<DbTask> dbTasks = _provider.Tasks.AsNoTracking();

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
        .ToListAsync(cancellationToken),
      await dbTasks.CountAsync(cancellationToken));
  }

  public async Task<DbTask> GetAsync(Guid id, GetTaskFilter filter, CancellationToken cancellationToken = default)
  {
    return await IncludeRelatedEntities(filter, _provider.Tasks).AsNoTracking().FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
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
    // TODO: Wait for groups implementation
    //if (filter.IncludeGroup)
    //{
    //  dbTasks = dbTasks.Include(t => t.Group);
    //}

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