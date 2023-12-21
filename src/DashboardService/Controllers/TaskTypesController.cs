using LT.DigitalOffice.DashboardService.Business.TaskType;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType.Filters;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class TaskTypesController : ControllerBase
{
  [HttpPost]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] CreateTaskTypeCommand command,
    [FromBody] CreateTaskTypeRequest request)
  {
    return await command.ExecuteAsync(request);
  }
  
  [HttpGet]
  public async Task<FindResultResponse<TaskTypeInfo>> GetAsync(
    [FromServices] GetTaskTypesCommand command,
    [FromQuery] GetTaskTypesFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }
  
  [HttpGet("{id}")]
  public async Task<OperationResultResponse<TaskTypeInfo>> GetAsync(
    [FromServices] GetTaskTypeCommand command,
    [FromRoute] Guid id)
  {
    return await command.ExecuteAsync(id);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> PatchAsync(
    [FromServices] EditTaskTypeCommand command,
    [FromRoute] Guid id,
    [FromBody] JsonPatchDocument<PatchTaskTypeRequest> request)
  {
    return await command.ExecuteAsync(id, request);
  }
  
  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] RemoveTaskTypeCommand command,
    [FromRoute] Guid id)
  {
    return await command.ExecuteAsync(id);
  }
}