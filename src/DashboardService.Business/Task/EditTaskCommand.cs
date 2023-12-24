using FluentValidation.Results;
using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Edit.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.DashboardService.Validation.Tasks.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task;

public class EditTaskCommand : IEditTaskCommand
{
  private readonly ITaskRepository _taskRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly IEditTaskRequestValidator _validator;
  private readonly IEditDbTaskMapper _mapper;

  public EditTaskCommand(
    ITaskRepository taskRepository,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    IEditTaskRequestValidator validator,
    IEditDbTaskMapper mapper)
  {
    _taskRepository = taskRepository;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
    _validator = validator;
    _mapper = mapper;
  }
  
  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<EditTaskRequest> request, CancellationToken ct)
  {
    if (!await _accessValidator.IsAdminAsync())
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
    }
    
    ValidationResult validationResult = await _validator.ValidateAsync((id, request), ct);
    
    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<bool>(
        HttpStatusCode.BadRequest,
        validationResult.Errors.ConvertAll(vf => vf.ErrorMessage));
    }

    return new()
    {
      Body = await _taskRepository.EditAsync(id, _mapper.Map(request), ct)
    };
  }
}