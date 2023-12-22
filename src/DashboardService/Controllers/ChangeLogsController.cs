using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChangeLogsController : ControllerBase
{
  [HttpGet("{id}")]
  public async Task<OperationResultResponse<ChangeLogResponse>> GetAsync(
    [FromServices] IGetChangeLogCommand command,
    [FromRoute] Guid id,
    [FromQuery] GetChangeLogFilter filter)
  {
    return await command.ExecuteAsync(id, filter);
  }

  [HttpGet]
  public async Task<FindResultResponse<ChangeLogInfo>> GetAsync(
  [FromServices] IGetChangeLogsCommand command,
  [FromQuery] GetChangeLogsFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }
}
