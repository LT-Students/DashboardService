using LT.DigitalOffice.DashboardService.Business.Comment;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
  [HttpPost]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreateCommentRequest request,
    [FromServices] CreateCommentCommand command)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet]
  public async Task<FindResultResponse<CommentInfo>> GetAsync(
    [FromServices] GetCommentsCommand command,
    [FromQuery] GetCommentsFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }

  [HttpGet("{id}")]
  public async Task<OperationResultResponse<CommentResponse>> GetAsync(
    [FromRoute] Guid id,
    [FromServices] GetCommentCommand command,
    [FromQuery] GetCommentFilter filter)
  {
    return await command.ExecuteAsync(id, filter);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> PatchAsync(
    [FromRoute] Guid id,
    [FromBody] PatchCommentRequest request,
    [FromServices] EditCommentCommand command)
  {
    return await command.ExecuteAsync(id, request);
  }

  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromRoute] Guid id,
    [FromServices] RemoveCommentCommand command)
  {
    return await command.ExecuteAsync(id);
  }
}