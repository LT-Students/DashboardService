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
  [HttpPost]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] CreatePriorityCommand command,
    [FromBody] CreatePriorityRequest request)
  {
    return await command.ExecuteAsync(request);
  }
  
  [HttpGet]
  public async Task<FindResultResponse<PriorityInfo>> GetAsync(
    [FromServices] GetPrioritiesCommand command,
    [FromQuery] GetPrioritiesFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }
  
  [HttpGet("{id}")]
  public async Task<OperationResultResponse<PriorityInfo>> GetAsync(
    [FromServices] GetPriorityCommand command,
    [FromRoute] Guid id)
  {
    return await command.ExecuteAsync(id);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] EditPriorityCommand command,
    [FromRoute] Guid id, 
    [FromBody] JsonPatchDocument<PatchPriorityRequest> request)
  {
    return await command.ExecuteAsync(id, request);
  }
  
  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] RemovePriorityCommand command,
    [FromRoute] Guid id)
  {
    return await command.ExecuteAsync(id);
  }
}