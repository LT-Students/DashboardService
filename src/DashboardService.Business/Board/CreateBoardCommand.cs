using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;
using System;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class CreateBoardCommand : ICreateBoardCommand
{
  public Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateBoardRequest request)
  {
    throw new NotImplementedException();
  }
}

