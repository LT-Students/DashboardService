using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Controllers;

[Route("[controller]")]
[ApiController]
public class PriorityController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreatePriorityRequest request)
  {
    throw new NotImplementedException();
  }

  [HttpGet("find")]
  public async Task<OperationResultResponse<IEnumerable<GetPriorityResponse>>> FindAsync()
  {
    throw new NotImplementedException();
  }
  
  [HttpGet("find/{id}")]
  public async Task<OperationResultResponse<GetPriorityResponse>> FindAsync([FromRoute] Guid id)
  {
    throw new NotImplementedException();
  }

  [HttpPatch("edit/{id}")]
  public async Task<OperationResultResponse<bool>> Patch(
    [FromRoute] Guid id, 
    [FromBody] PatchPriorityRequest request)
  {
    throw new NotImplementedException();
  }
  
  [HttpDelete("{id}")]
  public async Task<OperationResultResponse<bool>> Delete([FromRoute] Guid id)
  {
    throw new NotImplementedException();
  }
}