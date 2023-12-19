using LT.DigitalOffice.DashboardService.Business.Comment;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
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
    [FromServices] GetAllCommentsCommand command)
  {
    return await command.ExecuteAsync();
  }

  [HttpGet("{id}")]
  public async Task<OperationResultResponse<CommentResponse>> GetAsync(
    [FromRoute] Guid id,
    [FromServices] GetCommentCommand command)
  {
    return await command.ExecuteAsync(id);
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