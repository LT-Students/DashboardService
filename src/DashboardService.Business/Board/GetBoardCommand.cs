using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board
{
  public class FindBoardCommand : IFindBoardCommand
  {
    public Task<FindResultResponse<BoardInfo>> ExecuteAsync(Guid? id)
    {
      throw new NotImplementedException();
    }
  }
}
