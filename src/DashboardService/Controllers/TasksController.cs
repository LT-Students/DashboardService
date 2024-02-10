using DigitalOffice.Kernel.OpenApi.OperationFilters;
using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;
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
public class TasksController : ControllerBase
{
  /// <summary>
  /// Create new Task.
  /// </summary>
  /// <returns>
  /// Unique Task Id.
  /// </returns>
  [HttpPost]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<Guid>), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(OperationResultResponse<Guid?>), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(typeof(OperationResultResponse<Guid?>), StatusCodes.Status403Forbidden)]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateTaskCommand command,
    [FromBody] CreateTaskRequest request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(request, ct);
  }
  
  /// <summary>
  /// Get all Tasks of specific Group.
  /// </summary>
  /// <returns>
  /// List of Tasks info.
  /// </returns>
  [HttpGet]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(FindResultResponse<TaskInfo>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  public async Task<FindResultResponse<TaskInfo>> GetAsync(
    [FromServices] IGetTasksCommand command,
    [FromQuery] GetTasksFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }

  /// <summary>
  /// Get specific Task.
  /// </summary>
  /// <param name="id">
  /// Unique Task id.
  /// </param>
  /// <returns>
  /// Task info.
  /// </returns>
  [HttpGet("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(OperationResultResponse<TaskResponse>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(typeof(OperationResultResponse<TaskResponse>), StatusCodes.Status404NotFound)]
  public async Task<OperationResultResponse<TaskResponse>> GetAsync(
    [FromServices] IGetTaskCommand command,
    [FromRoute] Guid id,
    [FromQuery] GetTaskFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, filter, ct);
  }

  /// <summary>
  /// Patch specific Task.
  /// </summary>
  /// <param name="id">
  /// Unique Task id.
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
    [FromServices] IEditTaskCommand command,
    [FromRoute] Guid id, 
    [FromBody] JsonPatchDocument<EditTaskRequest> request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, request, ct);
  }
  
  /// <summary>
  /// Delete specific Task.
  /// </summary>
  /// <param name="id">
  /// Unique Task id.
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
    [FromServices] IRemoveTaskCommand command,
    [FromRoute] Guid id)
  {
    return await command.ExecuteAsync(id);
  }
}