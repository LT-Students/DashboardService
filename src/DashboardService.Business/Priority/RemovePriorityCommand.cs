using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class RemovePriorityCommand : IRemovePriorityCommand
{
  private readonly IPriorityRepository _priorityRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public RemovePriorityCommand(
    IPriorityRepository priorityRepository,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    IHttpContextAccessor httpContextAccessor)
  {
    _priorityRepository = priorityRepository;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
    _httpContextAccessor = httpContextAccessor;
  }
  
  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, CancellationToken ct)
  {
    if (!await _accessValidator.IsAdminAsync())
    {
      _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
    }
    
    if (!await _priorityRepository.RemoveAsync(id, ct))
    {
      return _responseCreator.CreateFailureResponse<bool>(
        HttpStatusCode.NotFound, 
        new() { "Cannot remove task priority with given Id" });
    }

    return new()
    {
      Body = true, 
    };
  }
}