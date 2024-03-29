﻿using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Provider;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data;

public class BoardRepository : IBoardRepository
{
  private readonly IDataProvider _provider;

  public BoardRepository(IDataProvider provider)
  {
    _provider = provider;
  }

  public async Task<Guid?> CreateAsync(DbBoard board)
  {
    _provider.Boards.Add(board);

    await _provider.SaveAsync();

    return board.Id;
  }

  public async Task<bool> EditByIdAsync(Guid id, Guid modifiedById, JsonPatchDocument<DbBoard> request, CancellationToken ct)
  {
    DbBoard board = await _provider.Boards.FindAsync(id, ct);

    if (board is null)
    {
      return false;
    }

    request.ApplyTo(board);

    board.ModifiedBy = modifiedById;
    board.ModifiedAtUtc = DateTime.UtcNow;

    await _provider.SaveAsync();

    return true;
  }

  public Task<DbBoard> GetAsync(Guid id, GetBoardFilter filter, CancellationToken ct)
  {
    IQueryable<DbBoard> boards = _provider.Boards.AsNoTracking();

    if (filter.IncludeGroups)
    {
      boards.Include(db => db.Groups);
    }

    return boards.FirstOrDefaultAsync(db => db.Id == id, ct);
  }

  public async Task<(List<DbBoard> boards, int totalCount)> GetAllAsync(GetBoardsFilter filter, CancellationToken ct)
  {
    IQueryable<DbBoard> boards = _provider.Boards.AsNoTracking();

    if (filter.ProjectId.HasValue)
    {
      boards = boards.Where(d => d.ProjectId == filter.ProjectId);
    }

    if (filter.IsActive.HasValue)
    {
      boards = boards.Where(d => d.IsActive == filter.IsActive);
    }

    if (filter.IsAscendingSort.HasValue)
    {
      boards = filter.IsAscendingSort.Value
        ? boards.OrderBy(db => db.Name)
        : boards.OrderByDescending(db => db.Name);
    }

    if (!string.IsNullOrWhiteSpace(filter.NameIncludeSubstring))
    {
      boards = boards.Where(db => db.Name.Contains(filter.NameIncludeSubstring));
    }

    return (
      await boards
        .Skip(filter.SkipCount)
        .Take(filter.TakeCount)
        .ToListAsync(ct),
      await boards.CountAsync(ct));
  }

  // TODO
  // Do I need to change ModifiedBy and ModifyAtUtc, if i change isActive ?

  public async Task<bool> RemoveAsync(Guid id, Guid modifiedById, CancellationToken ct)
  {
    DbBoard board = await _provider.Boards.FindAsync(id, ct);

    if (board is null)
    {
      return false;
    }

    board.IsActive = false;

    board.ModifiedBy = modifiedById;
    board.ModifiedAtUtc = DateTime.UtcNow;

    foreach (DbGroup group in board.Groups)
    {
      group.IsActive = false;

      group.ModifiedBy = modifiedById;
      group.ModifiedAtUtc = DateTime.UtcNow;
    }

    await _provider.SaveAsync();
    return true;
  }

  public Task<bool> NameExistAsync(string name, Guid projectId, CancellationToken ct, Guid? boardId = default)
  {
    IQueryable<DbBoard> boards = _provider.Boards.Where(x => x.IsActive && x.ProjectId == projectId);

    return boardId.HasValue
      ? boards.AnyAsync(x => x.Name == name && boardId != x.Id, ct)
      : boards.AnyAsync(x => x.Name == name, ct);
  }
}
