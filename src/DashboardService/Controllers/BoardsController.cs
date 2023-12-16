using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Responses;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoardsController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateBoardCommand command,
    [FromBody] CreateBoardRequest request)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet("find")]
  public async Task<OperationResultResponse<IEnumerable<BoardInfo>>> GetAsync(
    [FromServices] IGetAllBoardsCommand command)
  {
    return await command.ExecuteAsync();
  }

  [HttpGet("find/{id}")]
  public async Task<FindResultResponse<BoardInfo>> GetAsync(
    [FromServices] IGetBoardCommand command,
    [FromRoute] Guid id)
  {
    return await command.ExecuteAsync(id);
  }

  [HttpPatch("edit/{id}")]
  public async Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] IEditBoardCommand command,
    [FromRoute] Guid id,
    [FromBody] PatchBoardRequest request)
  {
    return await command.ExecuteAsync(id, request);
  }

  [HttpGet("remove/{id}")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] IRemoveBoardCommand command,
    [FromRoute] Guid id)
  {
    return await command.ExecuteAsync(id);
  }
}
