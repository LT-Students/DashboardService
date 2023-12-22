using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType.Filters;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class TaskTypesController : ControllerBase
{
  [HttpPost]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateTaskTypeCommand command,
    [FromBody] CreateTaskTypeRequest request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(request, ct);
  }
  
  [HttpGet]
  public async Task<FindResultResponse<TaskTypeInfo>> GetAsync(
    [FromServices] IGetTaskTypesCommand command,
    [FromQuery] GetTaskTypesFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }
  
  [HttpGet("{id}")]
  public async Task<OperationResultResponse<TaskTypeInfo>> GetAsync(
    [FromServices] IGetTaskTypeCommand command,
    [FromRoute] Guid id,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, ct);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] IEditTaskTypeCommand command,
    [FromRoute] Guid id,
    [FromBody] JsonPatchDocument<EditTaskTypeRequest> request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, request, ct);
  }
  
  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] IRemoveTaskTypeCommand command,
    [FromRoute] Guid id,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, ct);
  }
}