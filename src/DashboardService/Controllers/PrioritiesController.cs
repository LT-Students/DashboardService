using DigitalOffice.Kernel.OpenApi.OperationFilters;
using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority.Filters;
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
public class PrioritiesController : ControllerBase
{
  /// <summary>
  /// Create new Priority.
  /// </summary>
  /// <returns>
  /// Unique Priority Id.
  /// </returns>
  [HttpPost]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<Guid>), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(OperationResultResponse<Guid?>), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(typeof(OperationResultResponse<Guid?>), StatusCodes.Status403Forbidden)]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreatePriorityCommand command,
    [FromBody] CreatePriorityRequest request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(request, ct);
  }
  
  /// <summary>
  /// Get all Priorities.
  /// </summary>
  /// <returns>
  /// List of Priorities info.
  /// </returns>
  [HttpGet]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(FindResultResponse<PriorityInfo>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  public async Task<FindResultResponse<PriorityInfo>> GetAsync(
    [FromServices] IGetPrioritiesCommand command,
    [FromQuery] GetPrioritiesFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }
  
  /// <summary>
  /// Get specific Priority.
  /// </summary>
  /// <param name="id">
  /// Unique Priority id.
  /// </param>
  /// <returns>
  /// Priority info.
  /// </returns>
  [HttpGet("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<PriorityInfo>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(typeof(OperationResultResponse<PriorityInfo>), StatusCodes.Status404NotFound)]
  public async Task<OperationResultResponse<PriorityInfo>> GetAsync(
    [FromServices] IGetPriorityCommand command,
    [FromRoute] Guid id,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, ct);
  }
  
  /// <summary>
  /// Patch specific Priority.
  /// </summary>
  /// <param name="id">
  /// Unique Priority id.
  /// </param>
  /// <returns>
  /// Boolean result of patching.
  /// </returns>
  [HttpPatch("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status403Forbidden)]
  public async Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] IEditPriorityCommand command,
    [FromRoute] Guid id, 
    [FromBody] JsonPatchDocument<EditPriorityRequest> request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, request, ct);
  }
  
  /// <summary>
  /// Delete specific Priority.
  /// </summary>
  /// <param name="id">
  /// Unique Priority id.
  /// </param>
  /// <returns>
  /// Boolean result of deleting.
  /// </returns>
  [HttpDelete("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status403Forbidden)]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] IRemovePriorityCommand command,
    [FromRoute] Guid id,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, ct);
  }
}