using LT.DigitalOffice.DashboardService.Business.Priority;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
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

  [HttpGet("get")]
  public async Task<FindResultResponse<IEnumerable<PriorityInfo>>> GetAsync(
    [FromServices] GetAllPrioritiesCommand command
    )
  {
    return await command.ExecuteAsync();
  }
  
  [HttpGet("get/{id}")]
  public async Task<OperationResultResponse<PriorityResponse>> GetAsync(
    [FromRoute] Guid id,
    [FromServices] GetPriorityCommand command)
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