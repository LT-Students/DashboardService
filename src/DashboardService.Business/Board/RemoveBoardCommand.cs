using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class RemoveBoardCommand : IRemoveBoardCommand
{
  private readonly IBoardRepository _boardRepository;
  private readonly IResponseCreator _responseCreator;

  public RemoveBoardCommand(IBoardRepository boardRepository, IResponseCreator responseCreator)
  {
    _boardRepository = boardRepository;
    _responseCreator = responseCreator;
  }

  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid boardId)
  {
    throw new NotImplementedException();
  }
}
