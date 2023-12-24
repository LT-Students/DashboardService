using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task;

public class RemoveTaskCommand : IRemoveTaskCommand
{
  private readonly ITaskRepository _taskRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;

  public RemoveTaskCommand(
    ITaskRepository taskRepository,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator)
  {
    _taskRepository = taskRepository;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
  }
  
  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid id)
  {
    if (!await _accessValidator.IsAdminAsync())
    {
      _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
    }

    if (!await _taskRepository.RemoveAsync(id))
    {
      return _responseCreator.CreateFailureResponse<bool>(
        HttpStatusCode.NotFound, 
        new() { "Cannot remove task with given Id" });
    }

    return new() 
    { 
      Body = true,
    };
  }
}