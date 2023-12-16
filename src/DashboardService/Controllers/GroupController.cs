using LT.DigitalOffice.DashboardService.Business.Group;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreateGroupRequest request,
    [FromServices] CreateGroupCommand command)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet("get")]
  public async Task<FindResultResponse<IEnumerable<GroupInfo>>> GetAsync(
    [FromServices] GetAllGroupsCommand command
  )
  {
    return await command.ExecuteAsync();
  }

  [HttpGet("get/{id}")]
  public async Task<OperationResultResponse<GroupResponse>> GetAsync(
    [FromRoute] Guid id,
    [FromServices] GetGroupCommand command)
  {
    return await command.ExecuteAsync(id);
  }

  [HttpPatch("edit/{id}")]
  public async Task<OperationResultResponse<bool>> Patch(
    [FromRoute] Guid id,
    [FromBody] PatchGroupRequest request,
    [FromServices] EditGroupCommand command)
  {
    return await command.ExecuteAsync(id, request);
  }

  [HttpDelete("delete/{id}")]
  public async Task<OperationResultResponse<bool>> Delete(
    [FromRoute] Guid id,
    [FromServices] DeleteGroupCommand command)
  {
    return await command.ExecuteAsync(id);
  }

}