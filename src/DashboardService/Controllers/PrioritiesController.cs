using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority.Filters;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class PrioritiesController : ControllerBase
{
  [HttpPost]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreatePriorityCommand command,
    [FromBody] CreatePriorityRequest request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(request, ct);
  }
  
  [HttpGet]
  public async Task<FindResultResponse<PriorityInfo>> GetAsync(
    [FromServices] IGetPrioritiesCommand command,
    [FromQuery] GetPrioritiesFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }
  
  [HttpGet("{id}")]
  public async Task<OperationResultResponse<PriorityInfo>> GetAsync(
    [FromServices] IGetPriorityCommand command,
    [FromRoute] Guid id,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, ct);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] IEditPriorityCommand command,
    [FromRoute] Guid id, 
    [FromBody] JsonPatchDocument<EditPriorityRequest> request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, request, ct);
  }
  
  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] IRemovePriorityCommand command,
    [FromRoute] Guid id,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, ct);
  }
}