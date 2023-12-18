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
    [FromBody] CreateTaskRequest request,
    [FromServices] CreateTaskCommand command)
  {
    return await command.ExecuteAsync(request);
  }
  
  [HttpGet]
  public async Task<FindResultResponse<TaskInfo>> GetAsync(
    [FromServices] GetTasksCommand command,
    [FromQuery] GetTasksFilter filter)
  {
    return await command.ExecuteAsync();
  }

  [HttpGet("{id}")]
  public async Task<OperationResultResponse<TaskResponse>> GetAsync(
    [FromRoute] Guid id,
    [FromQuery] GetTaskFilter filter,
    [FromServices] GetTaskCommand command)
  {
    return await command.ExecuteAsync(id);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> Patch(
    [FromRoute] Guid id, 
    [FromBody] JsonPatchDocument<PatchTaskRequest> request,
    [FromServices] EditTaskCommand command)
  {
    return await command.ExecuteAsync(id, request);
  }
  
  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> Delete(
    [FromRoute] Guid id,
    [FromServices] RemoveTaskCommand command)
  {
    return await command.ExecuteAsync(id);
  }
}