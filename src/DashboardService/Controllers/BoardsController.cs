using DigitalOffice.Kernel.OpenApi.OperationFilters;
using LT.DigitalOffice.DashboardService.Business.Board.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Exceptions.Models;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public class BoardsController : ControllerBase
{
  /// <summary>
  /// Create new Board.
  /// </summary>
  /// <returns>
  /// Unique Board Id.
  /// </returns>
  [HttpPost]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<Guid>), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(OperationResultResponse<Guid?>), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(typeof(OperationResultResponse<Guid?>), StatusCodes.Status403Forbidden)]

  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateBoardCommand command,
    [FromBody] CreateBoardRequest request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(request, ct);
  }

  /// <summary>
  /// Get all Boards of specific Project.
  /// </summary>
  /// <returns>
  /// List of Boards info.
  /// </returns>
  [HttpGet]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(FindResultResponse<BoardInfo>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]

  public async Task<FindResultResponse<BoardInfo>> GetAsync(
    [FromServices] IGetBoardsCommand command,
    [FromQuery] GetBoardsFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }

  /// <summary>
  /// Get specific Board.
  /// </summary>
  /// <param name="id">
  /// Unique Board id.
  /// </param>
  /// <returns>
  /// Board info.
  /// </returns>
  [HttpGet("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<BoardResponse>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(typeof(OperationResultResponse<BoardResponse>), StatusCodes.Status404NotFound)]

  public async Task<OperationResultResponse<BoardResponse>> GetAsync(
    [FromServices] IGetBoardCommand command,
    [FromRoute] Guid id,
    [FromQuery] GetBoardFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, filter, ct);
  }

  /// <summary>
  /// Patch specific Board.
  /// </summary>
  /// <param name="id">
  /// Unique Board id.
  /// </param>
  /// <returns>
  /// Boolean result of patching.
  /// </returns>
  [HttpPatch("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status403Forbidden)]
  public async Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] IEditBoardCommand command,
    [FromRoute] Guid id,
    [FromBody] JsonPatchDocument<PatchBoardRequest> request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, request, ct);
  }

  /// <summary>
  /// Delete specific Board.
  /// </summary>
  /// <param name="id">
  /// Unique Board id.
  /// </param>
  /// <returns>
  /// Boolean result of deleting.
  /// </returns>
  [HttpDelete("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status403Forbidden)]

  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] IRemoveBoardCommand command,
    [FromRoute] Guid id,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, ct);
  }
}
