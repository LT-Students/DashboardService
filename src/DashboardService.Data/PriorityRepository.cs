using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority.Filters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class PriorityRepository : IPriorityRepository
{
  private readonly IDataProvider _provider;

  public PriorityRepository(IDataProvider provider)
  {
    _provider = provider;
  }
  
  public async Task<Guid?> CreateAsync(DbPriority dbPriority)
  {
    _provider.Priorities.Add(dbPriority);
    await _provider.SaveAsync();

    return dbPriority.Id;
  }

  public async Task<(List<DbPriority> dbPriorities, int totalCount)> GetAllAsync(GetPrioritiesFilter filter, CancellationToken ct)
  {
    IQueryable<DbPriority> dbPriorities = _provider.Priorities.AsNoTracking();
    
    if (filter.IsAscendingSort.HasValue)
    {
      dbPriorities = filter.IsAscendingSort.Value
        ? dbPriorities.OrderBy(d => d.Name)
        : dbPriorities.OrderByDescending(d => d.Name);
    }
    
    if (!string.IsNullOrWhiteSpace(filter.NameIncludeSubstring))
    {
      dbPriorities = dbPriorities.Where(d => d.Name.Contains(filter.NameIncludeSubstring));
    }
    
    return (
      await dbPriorities
        .Skip(filter.SkipCount)
        .Take(filter.TakeCount)
        .ToListAsync(ct),
      await dbPriorities.CountAsync(ct));
  }

  public async Task<DbPriority> GetAsync(Guid id, CancellationToken ct)
  {
    return await _provider.Priorities.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);
  }

  public async Task<bool> EditAsync(Guid id, JsonPatchDocument<DbPriority> request, CancellationToken ct)
  {
    DbPriority dbPriority = await _provider.Priorities.FindAsync(id);

    if (dbPriority is null)
    {
      return false;
    }
    
    request.ApplyTo(dbPriority);

    await _provider.SaveAsync();

    return true;
  }

  public async Task<bool> RemoveAsync(Guid id, CancellationToken ct)
  {
    DbPriority dbPriority = await GetAsync(id, ct);

    if (dbPriority is null)
    {
      return false;
    }
    
    _provider.Priorities.Remove(dbPriority);
    await _provider.SaveAsync();

    return true;
  }

  public Task<bool> NameExistAsync(string name, CancellationToken ct, Guid? priorityId = default)
  {
    return priorityId.HasValue
      ? _provider.Priorities.AnyAsync(d => d.Name == name && d.Id != priorityId, ct)
      : _provider.Priorities.AnyAsync(d => d.Name == name, ct);
  }
}