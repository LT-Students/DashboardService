using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class GetBoardCommand : IGetBoardCommand
{
  private readonly IBoardRepository _boardRepository;
  private readonly IBoardResponseMapper _boardResponseMapper;
  private readonly IResponseCreator _responseCreator;
  private readonly IGroupInfoMapper _groupInfoMapper;

  public GetBoardCommand(
    IBoardRepository repository,
    IBoardResponseMapper boardResponseMapper,
    IResponseCreator responseCreator,
    IGroupInfoMapper groupInfoMapper)
  {
    _boardRepository = repository;
    _boardResponseMapper = boardResponseMapper;
    _responseCreator = responseCreator;
    _groupInfoMapper = groupInfoMapper;
  }

  public async Task<OperationResultResponse<BoardResponse>> ExecuteAsync(Guid id, GetBoardFilter filter, CancellationToken ct)
  {
    DbBoard dbBoard = await _boardRepository.GetAsync(id, filter, ct);

    if (dbBoard is null)
    {
      return _responseCreator.CreateFailureResponse<BoardResponse>(HttpStatusCode.NotFound);
    }

    return new OperationResultResponse<BoardResponse>(
      body: _boardResponseMapper.Map(dbBoard, (x) => _groupInfoMapper.Map(x)));
  }
}
