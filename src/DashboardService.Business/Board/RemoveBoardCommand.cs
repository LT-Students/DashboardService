using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Extensions;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Board;

public class RemoveBoardCommand : IRemoveBoardCommand
{
  private readonly IBoardRepository _boardRepository;
  private readonly IHttpContextAccessor _httpContext;
  private readonly IResponseCreator _responseCreator;
  private readonly IAccessValidator _accessValidator;

  public RemoveBoardCommand(
    IBoardRepository boardRepository,
    IHttpContextAccessor contextAccessor,
    IResponseCreator responseCreator,
    IAccessValidator accessValidator)
  {
    _boardRepository = boardRepository;
    _httpContext = contextAccessor;
    _responseCreator = responseCreator;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid boardId, CancellationToken ct)
  {
    if (!await _accessValidator.IsAdminAsync())
    {
      _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
    }

    if (!await _boardRepository.RemoveAsync(boardId, _httpContext.HttpContext.GetUserId(), ct))
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
