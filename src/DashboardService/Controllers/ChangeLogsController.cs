using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using System.Threading;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class ChangeLogsController : ControllerBase
{
  [HttpGet]
  public async Task<FindResultResponse<ChangeLogInfo>> GetAsync(
    [FromServices] IGetChangeLogsCommand command,
    [FromQuery] GetChangeLogsFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }
}
