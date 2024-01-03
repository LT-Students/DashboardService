using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class BoardsController : ControllerBase
{
  [HttpPost]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateBoardCommand command,
    [FromBody] CreateBoardRequest request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(request, ct);
  }

  [HttpGet]
  public async Task<FindResultResponse<BoardInfo>> GetAsync(
    [FromServices] IGetBoardsCommand command,
    [FromQuery] GetBoardsFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }

  [HttpGet("{id}")]
  public async Task<OperationResultResponse<BoardResponse>> GetAsync(
    [FromServices] IGetBoardCommand command,
    [FromRoute] Guid id,
    [FromQuery] GetBoardFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, filter, ct);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] IEditBoardCommand command,
    [FromRoute] Guid id,
    [FromBody] JsonPatchDocument<PatchBoardRequest> request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, request, ct);
  }

  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] IRemoveBoardCommand command,
    [FromRoute] Guid id,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, ct);
  }
}
