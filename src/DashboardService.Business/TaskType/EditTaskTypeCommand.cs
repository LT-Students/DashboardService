using FluentValidation.Results;
using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Edit.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.DashboardService.Validation.TaskType.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType;

public class EditTaskTypeCommand : IEditTaskTypeCommand
{
  private readonly ITaskTypeRepository _taskTypeRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly IEditTaskTypeRequestValidator _validator;
  private readonly IEditDbTaskTypeMapper _mapper;

  public EditTaskTypeCommand(
    ITaskTypeRepository repository,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    IEditTaskTypeRequestValidator validator,
    IEditDbTaskTypeMapper mapper)
  {
    _taskTypeRepository = repository;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
    _validator = validator;
    _mapper = mapper;
  }
  
  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<EditTaskTypeRequest> request, CancellationToken ct)
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
      Body = await _taskTypeRepository.EditAsync(id, _mapper.Map(request), ct)
    };
  }
}