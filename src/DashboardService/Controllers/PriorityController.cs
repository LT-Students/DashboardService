using LT.DigitalOffice.DashboardService.Business.Priority;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class PriorityController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreatePriorityRequest request,
    [FromServices] CreatePriorityCommand command)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet("find")]
  public async Task<FindResultResponse<IEnumerable<PriorityInfo>>> FindAsync(
    [FromServices] FindAllPrioritiesCommand command
    )
  {
    return await command.ExecuteAsync();
  }
  
  [HttpGet("find/{id}")]
  public async Task<OperationResultResponse<PriorityInfo>> FindAsync(
    [FromRoute] Guid id,
    [FromServices] FindPriorityCommand command)
  {
    return await command.ExecuteAsync(id);
  }

  [HttpPatch("edit/{id}")]
  public async Task<OperationResultResponse<bool>> Patch(
    [FromRoute] Guid id, 
    [FromBody] PatchPriorityRequest request,
    [FromServices] EditPriorityCommand command)
  {
    return await command.ExecuteAsync(id, request);
  }
  
  [HttpDelete("delete/{id}")]
  public async Task<OperationResultResponse<bool>> Delete(
    [FromRoute] Guid id,
    [FromServices] DeletePriorityCommand command)
  {
    return await command.ExecuteAsync(id);
  }
}