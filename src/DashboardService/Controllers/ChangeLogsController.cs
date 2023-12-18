using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;
using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.JsonPatch;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using LT.DigitalOffice.DashboardService.Models.Dto.Responces;

namespace LT.DigitalOffice.DashboardService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ChangeLogsController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
  [FromServices] ICreateChangeLogCommand command,
  [FromBody] CreateChangeLogRequest request)
  {
    return await command.ExecuteAsync(request);
  }

  public async Task<FindResultResponse<ChangeLogInfo>> GetAsync(
    [FromServices] IGetAllChangeLogsCommand command,
    [FromQuery] GetChangeLogsFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }

  [HttpGet("{id}")]
  public async Task<OperationResultResponse<ChangeLogResponce>> GetAsync(
    [FromServices] IGetChangeLogCommand command,
    [FromRoute] Guid id,
    [FromQuery] GetChangeLogFilter filter)
  {
    return await command.ExecuteAsync(id, filter);
  }

  [HttpPatch("{id}")]
  public async Task<OperationResultResponse<bool>> PatchAsync(
    [FromServices] IEditChangeLogCommand command,
    [FromRoute] Guid id,
    [FromBody] JsonPatchDocument<PatchChangeLogRequest> request)
  {
    return await command.ExecuteAsync(id, request);
  }

  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] IRemoveChangeLogCommand command,
    [FromRoute] Guid id)
  {
    return await command.ExecuteAsync(id);
  }


}
