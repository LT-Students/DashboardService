using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
  [HttpPost]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateTaskCommand command,
    [FromBody] CreateTaskRequest request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(request, ct);
  }
  
  [HttpGet]
  public async Task<FindResultResponse<TaskInfo>> GetAsync(
    [FromServices] IGetTasksCommand command,
    [FromQuery] GetTasksFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }

  [HttpGet("{id}")]
  public async Task<OperationResultResponse<TaskResponse>> GetAsync(
    [FromServices] IGetTaskCommand command,
    [FromRoute] Guid id,
    [FromQuery] GetTaskFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, filter, ct);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] IEditTaskCommand command,
    [FromRoute] Guid id, 
    [FromBody] JsonPatchDocument<EditTaskRequest> request,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(id, request, ct);
  }
  
  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] IRemoveTaskCommand command,
    [FromRoute] Guid id)
  {
    return await command.ExecuteAsync(id);
  }
}