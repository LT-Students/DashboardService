using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board.Interfaces;

[AutoInject]
public interface IGetBoardCommand
{
  Task<OperationResultResponse<BoardResponse>> ExecuteAsync(Guid id, GetBoardFilter filter, CancellationToken ct);
}
