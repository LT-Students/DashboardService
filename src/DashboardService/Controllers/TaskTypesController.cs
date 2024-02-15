using DigitalOffice.Kernel.OpenApi.OperationFilters;
using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType.Filters;
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
public class TaskTypesController : ControllerBase
{
  /// <summary>
  /// Create new Task type.
  /// </summary>
  /// <returns>
  /// Unique Task type Id.
  /// </returns>
  [HttpPost]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<Guid>), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(OperationResultResponse<Guid?>), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(typeof(OperationResultResponse<Guid?>), StatusCodes.Status403Forbidden)]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateTaskTypeCommand command,
    [FromBody] CreateTaskTypeRequest request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(request, ct);
  }
  
  /// <summary>
  /// Get all Tasks types.
  /// </summary>
  /// <returns>
  /// List of Tasks types.
  /// </returns>
  [HttpGet]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(FindResultResponse<TaskTypeInfo>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  public async Task<FindResultResponse<TaskTypeInfo>> GetAsync(
    [FromServices] IGetTaskTypesCommand command,
    [FromQuery] GetTaskTypesFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }
  
  /// <summary>
  /// Get specific Task type.
  /// </summary>
  /// <param name="id">
  /// Unique Task type id.
  /// </param>
  /// <returns>
  /// Task type info.
  /// </returns>
  [HttpGet("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<TaskTypeInfo>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(typeof(OperationResultResponse<TaskTypeInfo>), StatusCodes.Status404NotFound)]
  public async Task<OperationResultResponse<TaskTypeInfo>> GetAsync(
    [FromServices] IGetTaskTypeCommand command,
    [FromRoute] Guid id,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, ct);
  }

  /// <summary>
  /// Patch specific Task type.
  /// </summary>
  /// <param name="id">
  /// Unique Task type id.
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
    [FromServices] IEditTaskTypeCommand command,
    [FromRoute] Guid id,
    [FromBody] JsonPatchDocument<EditTaskTypeRequest> request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, request, ct);
  }
  
  /// <summary>
  /// Delete specific Task type.
  /// </summary>
  /// <param name="id">
  /// Unique Task type id.
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
    [FromServices] IRemoveTaskTypeCommand command,
    [FromRoute] Guid id,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, ct);
  }
}