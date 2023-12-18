using LT.DigitalOffice.DashboardService.Business.Priority;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority.Filters;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class PrioritiesController : ControllerBase
{
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreatePriorityRequest request,
    [FromServices] CreatePriorityCommand command)
  {
    return await command.ExecuteAsync(request);
  }
  
  public async Task<FindResultResponse<PriorityInfo>> GetAsync(
    [FromServices] GetPrioritiesCommand command,
    [FromQuery] GetPrioritiesFilter filter)
  {
    return await command.ExecuteAsync();
  }
  
  [HttpGet("{id}")]
  public async Task<OperationResultResponse<PriorityInfo>> GetAsync(
    [FromRoute] Guid id,
    [FromServices] GetPriorityCommand command)
  {
    return await command.ExecuteAsync(id);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> Patch(
    [FromRoute] Guid id, 
    [FromBody] JsonPatchDocument<PatchPriorityRequest> request,
    [FromServices] EditPriorityCommand command)
  {
    return await command.ExecuteAsync(id, request);
  }
  
  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> Delete(
    [FromRoute] Guid id,
    [FromServices] RemovePriorityCommand command)
  {
    return await command.ExecuteAsync(id);
  }
}