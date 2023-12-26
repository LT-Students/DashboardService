using LT.DigitalOffice.DashboardService.Business.Group;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class GroupsController : ControllerBase
{
  [HttpPost]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreateGroupRequest request,
    [FromServices] CreateGroupCommand command)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet]
  public async Task<FindResultResponse<GroupInfo>> GetAsync(
    [FromServices] GetGroupsCommand command,
    [FromQuery] GetGroupsFilter filter
  )
  {
    return await command.ExecuteAsync(filter);
  }

  [HttpGet("{id}")]
  public async Task<OperationResultResponse<GroupResponse>> GetAsync(
    [FromRoute] Guid id,
    [FromServices] GetGroupCommand command,
    [FromQuery] GetGroupFilter filter)
  {
    return await command.ExecuteAsync(filter, id);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> Patch(
    [FromRoute] Guid id,
    [FromBody] PatchGroupRequest request,
    [FromServices] EditGroupCommand command)
  {
    return await command.ExecuteAsync(id, request);
  }

  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> Remove(
    [FromRoute] Guid id,
    [FromServices] RemoveGroupCommand command)
  {
    return await command.ExecuteAsync(id);
  }
}