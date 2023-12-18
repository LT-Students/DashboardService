using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class GetAllBoardsCommand : IGetAllBoardsCommand
{
  public Task<FindResultResponse<BoardInfo>> ExecuteAsync()
  {
    throw new System.NotImplementedException();
  }
}
