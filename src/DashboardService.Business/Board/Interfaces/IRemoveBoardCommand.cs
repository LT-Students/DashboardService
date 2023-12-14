using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board.Interfaces;

public interface IRemoveBoardCommand
{
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid? boardId);
}
