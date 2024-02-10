using DigitalOffice.Kernel.OpenApi.OperationFilters;
using LT.DigitalOffice.DashboardService.Business.Group;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public class GroupsController : ControllerBase
{
  /// <summary>
  /// Create new Group.
  /// </summary>
  /// <returns>
  /// Unique Group Id.
  /// </returns>
  [HttpPost]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  // TODO: add status codes after realization
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreateGroupRequest request,
    [FromServices] CreateGroupCommand command)
  {
    return await command.ExecuteAsync(request);
  }

  /// <summary>
  /// Get all Groups.
  /// </summary>
  /// <returns>
  /// List of Groups info.
  /// </returns>
  [HttpGet]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  // TODO: add status codes after realization
  public async Task<FindResultResponse<GroupInfo>> GetAsync(
    [FromServices] GetGroupsCommand command,
    [FromQuery] GetGroupsFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }

  /// <summary>
  /// Get specific Group.
  /// </summary>
  /// <param name="id">
  /// Unique Group id.
  /// </param>
  /// <returns>
  /// Group info.
  /// </returns>
  [HttpGet("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  // TODO: add status codes after realization
  public async Task<OperationResultResponse<GroupResponse>> GetAsync(
    [FromRoute] Guid id,
    [FromServices] GetGroupCommand command,
    [FromQuery] GetGroupFilter filter)
  {
    return await command.ExecuteAsync(filter, id);
  }

  /// <summary>
  /// Patch specific Group.
  /// </summary>
  /// <param name="id">
  /// Unique Group id.
  /// </param>
  /// <returns>
  /// Boolean result of patching.
  /// </returns>
  [HttpPatch("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  // TODO: add status codes after realization
  public async Task<OperationResultResponse<bool>> Patch(
    [FromRoute] Guid id,
    [FromBody] JsonPatchDocument<EditGroupRequest> request,
    [FromServices] EditGroupCommand command)
  {
    return await command.ExecuteAsync(id, request);
  }

  /// <summary>
  /// Delete specific Group.
  /// </summary>
  /// <param name="id">
  /// Unique Group id.
  /// </param>
  /// <returns>
  /// Boolean result of deleting.
  /// </returns>
  [HttpDelete("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  // TODO: add status codes after realization
  public async Task<OperationResultResponse<bool>> Remove(
    [FromRoute] Guid id,
    [FromServices] RemoveGroupCommand command)
  {
    return await command.ExecuteAsync(id);
  }
}