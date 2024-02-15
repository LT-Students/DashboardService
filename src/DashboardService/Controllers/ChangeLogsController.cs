using DigitalOffice.Kernel.OpenApi.OperationFilters;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Exceptions.Models;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public class ChangeLogsController : ControllerBase
{
  /// <summary>
  /// Get all ChangeLogs of specific Task.
  /// </summary>
  /// <returns>
  /// List of ChangeLogs info.
  /// </returns>
  [HttpGet]
  [SwaggerOperationFilter(typeof(TokenOperationFilter))]
  [ProducesResponseType(typeof(FindResultResponse<ChangeLogInfo>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  public async Task<FindResultResponse<ChangeLogInfo>> GetAsync(
    [FromServices] IGetChangeLogsCommand command,
    [FromQuery] GetChangeLogsFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }
}
