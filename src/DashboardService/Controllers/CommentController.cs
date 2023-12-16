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
public class CommentController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreateCommentRequest request,
    [FromServices] CreateCommentCommand command)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet("get")]
  public async Task<FindResultResponse<IEnumerable<CommentInfo>>> GetAsync(
    [FromServices] GetAllCommentsCommand command
  )
  {
    return await command.ExecuteAsync();
  }

  [HttpGet("get/{id}")]
  public async Task<OperationResultResponse<CommentResponse>> GetAsync(
    [FromRoute] Guid id,
    [FromServices] GetCommentCommand command)
  {
    return await command.ExecuteAsync(id);
  }

  [HttpPatch("edit/{id}")]
  public async Task<OperationResultResponse<bool>> Patch(
    [FromRoute] Guid id,
    [FromBody] PatchCommentRequest request,
    [FromServices] EditCommentCommand command)
  {
    return await command.ExecuteAsync(id, request);
  }

  [HttpDelete("delete/{id}")]
  public async Task<OperationResultResponse<bool>> Delete(
    [FromRoute] Guid id,
    [FromServices] DeleteCommentCommand command)
  {
    return await command.ExecuteAsync(id);
  }

}