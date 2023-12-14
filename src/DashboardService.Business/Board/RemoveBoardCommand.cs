using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board
{
  public class RemoveBoardCommand : IRemoveBoardCommand
  {
    public Task<OperationResultResponse<bool>> ExecuteAsync(Guid? boardId)
    {
      throw new NotImplementedException();
    }
  }
}
