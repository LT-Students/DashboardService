using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class RemoveBoardCommand : IRemoveBoardCommand
{
  private readonly IBoardRepository _boardRepository;
  private readonly IResponseCreator _responseCreator;
  private readonly IGroupRepository _groupRepository;

  public RemoveBoardCommand(
    IBoardRepository boardRepository,
    IResponseCreator responseCreator,
    IGroupRepository groupRepository)
  {
    _boardRepository = boardRepository;
    _responseCreator = responseCreator;
    _groupRepository = groupRepository;
  }

  // TODO
  // Only is admin can remove board? Or role?

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid boardId, CancellationToken ct)
  {
    if (!await _boardRepository.RemoveAsync(boardId, ct, _groupRepository))
    {
      return _responseCreator.CreateFailureResponse<bool>(
        HttpStatusCode.NotFound,
        new() { $"Cannot remove board with id: {boardId}." });
    }

    return new()
    {
      Body = true,
    };
  }
}
