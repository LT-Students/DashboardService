using DigitalOffice.Kernel.OpenApi.OperationFilters;
using LT.DigitalOffice.DashboardService.Business.Comment;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment.Filters;
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
public class CommentsController : ControllerBase
{
  /// <summary>
  /// Create new Comment.
  /// </summary>
  /// <returns>
  /// Unique Comment Id
  /// </returns>
  [HttpPost]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  // TODO: add status codes after realization
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreateCommentRequest request,
    [FromServices] CreateCommentCommand command)
  {
    return await command.ExecuteAsync(request);
  }

  /// <summary>
  /// Get all Comments.
  /// </summary>
  /// <returns>
  /// List of Comments info
  /// </returns>
  [HttpGet]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  // TODO: add status codes after realization
  public async Task<FindResultResponse<CommentInfo>> GetAsync(
    [FromServices] GetCommentsCommand command,
    [FromQuery] GetCommentsFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }

  /// <summary>
  /// Get specific Comment.
  /// </summary>
  /// <param name="id">
  /// Unique Comment id
  /// </param>
  /// <returns>
  /// Comment info
  /// </returns>
  [HttpGet("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  // TODO: add status codes after realization
  public async Task<OperationResultResponse<CommentResponse>> GetAsync(
    [FromRoute] Guid id,
    [FromServices] GetCommentCommand command,
    [FromQuery] GetCommentFilter filter)
  {
    return await command.ExecuteAsync(id, filter);
  }

  /// <summary>
  /// Patch specific Comment.
  /// </summary>
  /// <param name="id">
  /// Unique Comment id
  /// </param>
  /// <returns>
  /// Boolean result of patching
  /// </returns>
  [HttpPatch("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  // TODO: add status codes after realization
  public async Task<OperationResultResponse<bool>> PatchAsync(
    [FromRoute] Guid id,
    [FromBody] JsonPatchDocument<EditCommentRequest> request,
    [FromServices] EditCommentCommand command)
  {
    return await command.ExecuteAsync(id, request);
  }

  /// <summary>
  /// Delete specific Comment.
  /// </summary>
  /// <param name="id">
  /// Unique Comment id
  /// </param>
  /// <returns>
  /// Boolean result of deleting
  /// </returns>
  [HttpDelete("{id}")]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  // TODO: add status codes after realization
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromRoute] Guid id,
    [FromServices] RemoveCommentCommand command)
  {
    return await command.ExecuteAsync(id);
  }
}