﻿using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

  public async Task<Guid?> CreateAsync(DbChangeLog changeLog)
  {
    _provider.ChangeLogs.Add(changeLog);

    await _provider.SaveAsync();

    return changeLog.Id;
  }

  public async Task<bool> EditAsync(Guid changeLogId, JsonPatchDocument<DbChangeLog> request, CancellationToken ct)
  {
    DbChangeLog changeLog = await _provider.ChangeLogs.FirstOrDefaultAsync(x => x.Id == changeLogId, ct);

    if (changeLog is null || request is null)
    {
      return false;
    }

    request.ApplyTo(changeLog);

    await _provider.SaveAsync();

    return true;
  }

  public async Task<DbChangeLog> GetAsync(Guid changeLogId, CancellationToken ct)
  {
    return
      await _provider.ChangeLogs
        .AsNoTracking()
        .FirstOrDefaultAsync(db => db.Id == changeLogId, ct);
  }

  public async Task<(List<DbChangeLog>, int totalCount)> GetChangeLogsAsync(GetChangeLogsFilter filter, CancellationToken ct)
  {
    IQueryable<DbChangeLog> changeLogs = _provider.ChangeLogs.AsNoTracking();

    if (filter.TaskId.HasValue)
    {
      changeLogs = changeLogs.Where(d => d.TaskId == filter.TaskId);
    }

    if (filter.IsAscendingSortByCreatedAtUtc.HasValue && !filter.IsAscendingSortByEntityName.HasValue)
    {
      changeLogs = filter.IsAscendingSortByCreatedAtUtc.Value
        ? changeLogs.OrderBy(db => db.CreatedAtUtc)
        : changeLogs.OrderByDescending(db => db.CreatedAtUtc);
    }

    if (filter.IsAscendingSortByEntityName.HasValue && !filter.IsAscendingSortByCreatedAtUtc.HasValue)
    {
      changeLogs = filter.IsAscendingSortByEntityName.Value
        ? changeLogs.OrderBy(x => x.EntityName)
        : changeLogs.OrderByDescending(x => x.EntityName);
    }

    if (filter.IsAscendingSortByEntityName.HasValue && filter.IsAscendingSortByCreatedAtUtc.HasValue)
    {
      changeLogs = (filter.IsAscendingSortByEntityName.Value
        ? (filter.IsAscendingSortByCreatedAtUtc.Value
          ? changeLogs.OrderBy(x => x.EntityName).ThenBy(x => x.CreatedAtUtc)
          : changeLogs.OrderBy(x => x.EntityName).ThenByDescending(x => x.CreatedAtUtc))
        : (filter.IsAscendingSortByCreatedAtUtc.Value
          ? changeLogs.OrderByDescending(x => x.EntityName).ThenBy(x => x.CreatedAtUtc)
          : changeLogs.OrderByDescending(x => x.EntityName).ThenByDescending(x => x.CreatedAtUtc)));
    }

    if (!string.IsNullOrWhiteSpace(filter.EntityNameIncludeSubstring))
    {
      changeLogs = changeLogs.Where(db => db.EntityName.Contains(filter.EntityNameIncludeSubstring));
    }

    if (!string.IsNullOrWhiteSpace(filter.PropertyNameIncludeSubstring))
    {
      changeLogs = changeLogs.Where(db => db.PropertyName.Contains(filter.PropertyNameIncludeSubstring));
    }

    return (
      await changeLogs
        .Skip(filter.SkipCount)
        .Take(filter.TakeCount)
        .ToListAsync(ct),
      await changeLogs.CountAsync(ct));
  }

  public async Task<bool> RemoveByTaskIdAsync(Guid taskId, CancellationToken ct)
  {
    IQueryable<DbChangeLog> changeLogs =_provider.ChangeLogs.Where(x => x.TaskId == taskId);

    if (changeLogs is null)
    {
      return false;
    }

    await _provider.ChangeLogs.ForEachAsync(x => _provider.ChangeLogs.Remove(x), ct);

    await _provider.SaveAsync();

    return true;
  }
}
