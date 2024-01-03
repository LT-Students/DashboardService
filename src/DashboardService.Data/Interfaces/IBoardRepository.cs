using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.DashboardService.Models.Db;
using Microsoft.AspNetCore.JsonPatch;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;
using System.Threading;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface IBoardRepository
{
  Task<Guid?> CreateAsync(DbBoard board);

  Task<(List<DbBoard> boards, int totalCount)> GetAllAsync(GetBoardsFilter filter, CancellationToken ct);

  Task<DbBoard> GetAsync(Guid id, GetBoardFilter filter, CancellationToken ct);

  Task<bool> EditByIdAsync(Guid id, Guid modifiedById, JsonPatchDocument<DbBoard> request, CancellationToken ct);

  Task<bool> RemoveAsync(Guid id, CancellationToken ct);

  Task<bool> NameExistAsync(string name, CancellationToken ct, Guid? boardId = default);
}
