using LT.DigitalOffice.DashboardService.Business.TaskType;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
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
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreateTaskTypeRequest request,
    [FromServices] CreateTaskTypeCommand command)
  {
    return await command.ExecuteAsync(request);
  }
  
  public async Task<FindResultResponse<TaskTypeInfo>> GetAsync(
    [FromServices] GetTaskTypesCommand command)
  {
    return await command.ExecuteAsync();
  }
  
  [HttpGet("{id}")]
  public async Task<OperationResultResponse<TaskTypeInfo>> GetAsync(
    [FromRoute] Guid id,
    [FromServices] GetTaskTypeCommand command)
  {
    return await command.ExecuteAsync(id);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> Patch(
    [FromRoute] Guid id, 
    [FromBody] JsonPatchDocument<PatchTaskTypeRequest> request,
    [FromServices] EditTaskTypeCommand command)
  {
    return await command.ExecuteAsync(id, request);
  }
  
  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> Delete(
    [FromRoute] Guid id,
    [FromServices] DeleteTaskTypeCommand command)
  {
    return await command.ExecuteAsync(id);
  }
}