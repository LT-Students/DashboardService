using LT.DigitalOffice.DashboardService.Business.TaskType;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class TaskTypeController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreateTaskTypeRequest request,
    [FromServices] CreateTaskTypeCommand command)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet("get")]
  public async Task<FindResultResponse<IEnumerable<TaskTypeInfo>>> GetAsync(
    [FromServices] GetAllTaskTypesCommand command)
  {
    return await command.ExecuteAsync();
  }
  
  [HttpGet("get/{id}")]
  public async Task<OperationResultResponse<TaskTypeResponse>> GetAsync(
    [FromRoute] Guid id,
    [FromServices] GetTaskTypeCommand command)
  {
    return await command.ExecuteAsync(id);
  }

  [HttpPatch("edit/{id}")]
  public async Task<OperationResultResponse<bool>> Patch(
    [FromRoute] Guid id, 
    [FromBody] PatchTaskTypeRequest request,
    [FromServices] EditTaskTypeCommand command)
  {
    return await command.ExecuteAsync(id, request);
  }
  
  [HttpDelete("delete/{id}")]
  public async Task<OperationResultResponse<bool>> Delete(
    [FromRoute] Guid id,
    [FromServices] DeleteTaskTypeCommand command)
  {
    return await command.ExecuteAsync(id);
  }
}