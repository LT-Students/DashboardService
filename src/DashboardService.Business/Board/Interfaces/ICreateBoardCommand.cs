using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board.Interfaces;

[AutoInject]
public interface ICreateBoardCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateBoardRequest request, CancellationToken ct);
}
