using FluentValidation.Results;
using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.DashboardService.Validation.Tasks.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Extensions;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task;

public class CreateTaskCommand : ICreateTaskCommand
{
  private readonly ITaskRepository _taskRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly ICreateTaskRequestValidator _validator;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IDbTaskMapper _taskMapper;

  public CreateTaskCommand(
    ITaskRepository taskRepository,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    ICreateTaskRequestValidator validator,
    IHttpContextAccessor httpContextAccessor,
    IDbTaskMapper taskMapper)
  {
    _taskRepository = taskRepository;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
    _validator = validator;
    _httpContextAccessor = httpContextAccessor;
    _taskMapper = taskMapper;
  }
  
  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateTaskRequest request, CancellationToken ct)
  {
    Guid userId = _httpContextAccessor.HttpContext.GetUserId();
    
    if (!await _accessValidator.IsAdminAsync(userId))
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
      Body = await _taskRepository.CreateAsync(_taskMapper.Map(userId, request))
    };
  }
}