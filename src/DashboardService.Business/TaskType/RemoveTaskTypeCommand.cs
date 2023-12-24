using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType;

public class RemoveTaskTypeCommand : IRemoveTaskTypeCommand
{
  private readonly ITaskTypeRepository _taskTypeRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public RemoveTaskTypeCommand(
    ITaskTypeRepository repository,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    IHttpContextAccessor httpContextAccessor)
  {
    _taskTypeRepository = repository;
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

    if (!await _taskTypeRepository.RemoveAsync(id, ct))
    {
      return _responseCreator.CreateFailureResponse<bool>(
        HttpStatusCode.NotFound,
        new() { "Cannot remove task type with given Id" });
    }

    return new()
    {
      Body = true,
    };
  }
}