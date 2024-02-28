using LT.DigitalOffice.DashboardService.Business.User.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.DashboardUser;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Microsoft.AspNetCore.Components.Route("[Controller]")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public class UsersController
{
  /// <summary>
  /// Create new dashboard user.
  /// </summary>
  [HttpPost]
  //[SwaggerOperationFilter(typeof(TokenOperationFilter))]
  //[ProducesResponseType(typeof(Guid?), StatusCodes.Status201Created)]
  //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
  //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
  //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
  public async Task<OperationResultResponse<bool>> CreateAsync(
    [FromServices] ICreateDashboardUsersCommand command,
    [FromBody] CreateDashboardUsersRequest request)
  {
    return await command.ExecuteAsync(request);
  }
}