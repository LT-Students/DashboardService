using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class GetBoardsCommand : IGetBoardsCommand
{
  private readonly IBoardRepository _boardRepository;
  private readonly IBoardInfoMapper _boardInfoMapper;
  private readonly IResponseCreator _responseCreator;

  public GetBoardsCommand(
    IBoardRepository repository,
    IBoardInfoMapper boardInfoMapper,
    IResponseCreator responseCreator)
  {
    _boardRepository = repository;
    _boardInfoMapper = boardInfoMapper;
    _responseCreator = responseCreator;
  }


  public Task<FindResultResponse<BoardInfo>> ExecuteAsync(GetBoardsFilter filter)
  {
    throw new System.NotImplementedException();
  }
}
