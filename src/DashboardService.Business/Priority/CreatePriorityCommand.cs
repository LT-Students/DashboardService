using FluentValidation.Results;
using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.DashboardService.Validation.Priority.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class CreatePriorityCommand : ICreatePriorityCommand
{
  private readonly IPriorityRepository _priorityRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly ICreatePriorityRequestValidator _validator;
  private readonly IResponseCreator _responseCreator;
  private readonly IDbPriorityMapper _priorityMapper;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public CreatePriorityCommand(
    IPriorityRepository priorityRepository,
    IAccessValidator accessValidator,
    ICreatePriorityRequestValidator validator,
    IResponseCreator responseCreator,
    IDbPriorityMapper priorityMapper,
    IHttpContextAccessor httpContextAccessor)
  {
    _priorityRepository = priorityRepository;
    _accessValidator = accessValidator;
    _validator = validator;
    _responseCreator = responseCreator;
    _priorityMapper = priorityMapper;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePriorityRequest request, CancellationToken ct)
  {
    if (!await _accessValidator.IsAdminAsync())
    {
      return _responseCreator.CreateFailureResponse<Guid?>(HttpStatusCode.Forbidden);
    }
    
    ValidationResult validationResult = await _validator.ValidateAsync(request, ct);

    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<Guid?>(
        HttpStatusCode.BadRequest,
        validationResult.Errors.ConvertAll(vf => vf.ErrorMessage));
    }

    _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;

    return new()
    {
      Body = await _priorityRepository.CreateAsync(_priorityMapper.Map(request))
    };
  }
}