using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class GetBoardCommand : IGetBoardCommand
{
  private readonly IBoardRepository _boardRepository;
  private readonly IBoardResponseMapper _boardResponseMapper;
  private readonly IResponseCreator _responseCreator;

  public GetBoardCommand(
    IBoardRepository repository,
    IBoardResponseMapper boardResponseMapper,
    IResponseCreator responseCreator)
  {
    _boardRepository = repository;
    _boardResponseMapper = boardResponseMapper;
    _responseCreator = responseCreator;
  }

  public Task<OperationResultResponse<BoardResponse>> ExecuteAsync(Guid id, GetBoardFilter filter)
  {
    throw new NotImplementedException();
  }
}
