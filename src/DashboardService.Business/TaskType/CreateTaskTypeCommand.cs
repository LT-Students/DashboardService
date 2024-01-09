using FluentValidation.Results;
using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.DashboardService.Validation.TaskType.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType;

public class CreateTaskTypeCommand : ICreateTaskTypeCommand
{
  private readonly ITaskTypeRepository _taskTypeRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly ICreateTaskTypeRequestValidator _validator;
  private readonly IResponseCreator _responseCreator;
  private readonly IDbTaskTypeMapper _taskTypeMapper;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public CreateTaskTypeCommand(
    ITaskTypeRepository repository,
    IAccessValidator accessValidator,
    ICreateTaskTypeRequestValidator validator,
    IResponseCreator responseCreator,
    IDbTaskTypeMapper taskTypeMapper,
    IHttpContextAccessor httpContextAccessor)
  {
    _taskTypeRepository = repository;
    _accessValidator = accessValidator;
    _validator = validator;
    _responseCreator = responseCreator;
    _taskTypeMapper = taskTypeMapper;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateTaskTypeRequest request, CancellationToken ct)
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
      Body = await _taskTypeRepository.CreateAsync(_taskTypeMapper.Map(request))
    };
  }
}