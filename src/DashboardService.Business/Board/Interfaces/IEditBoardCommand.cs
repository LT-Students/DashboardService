using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;

namespace LT.DigitalOffice.DashboardService.Business.Board.Interfaces;

public interface IPatchBoardCommand
{
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, PatchBoardRequest request);
}
