using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;

using System;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class EditBoardCommand : IEditBoardCommand
{
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, PatchBoardRequest request)
  {
    throw new NotImplementedException();
  }
}
