using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class GetBoardCommand : IGetBoardCommand
{
  public Task<OperationResultResponse<BoardResponse>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}
