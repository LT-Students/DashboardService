using LT.DigitalOffice.DashboardService.Business.Task;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
  [HttpPost]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] CreateTaskCommand command,
    [FromBody] CreateTaskRequest request)
  {
    return await command.ExecuteAsync(request);
  }
  
  [HttpGet]
  public async Task<FindResultResponse<TaskInfo>> GetAsync(
    [FromServices] GetTasksCommand command,
    [FromQuery] GetTasksFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }

  [HttpGet("{id}")]
  public async Task<OperationResultResponse<TaskResponse>> GetAsync(
    [FromServices] GetTaskCommand command,
    [FromRoute] Guid id,
    [FromQuery] GetTaskFilter filter)
  {
    return await command.ExecuteAsync(id, filter);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] EditTaskCommand command,
    [FromRoute] Guid id, 
    [FromBody] JsonPatchDocument<PatchTaskRequest> request)
  {
    return await command.ExecuteAsync(id, request);
  }
  
  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] RemoveTaskCommand command,
    [FromRoute] Guid id)
  {
    return await command.ExecuteAsync(id);
  }
}