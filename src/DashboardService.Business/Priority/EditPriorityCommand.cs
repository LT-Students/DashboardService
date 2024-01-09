using FluentValidation.Results;
using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Edit.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.DashboardService.Validation.Priority.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class EditPriorityCommand : IEditPriorityCommand
{
  private readonly IPriorityRepository _priorityRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly IEditPriorityRequestValidator _validator;
  private readonly IEditDbPriorityMapper _mapper;

  public EditPriorityCommand(
    IPriorityRepository priorityRepository,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    IEditPriorityRequestValidator validator,
    IEditDbPriorityMapper mapper)
  {
    _priorityRepository = priorityRepository;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
    _validator = validator;
    _mapper = mapper;
  }
  
  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<EditPriorityRequest> request, CancellationToken ct)
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
      Body = await _priorityRepository.EditAsync(id, _mapper.Map(request), ct)
    };
  }
}