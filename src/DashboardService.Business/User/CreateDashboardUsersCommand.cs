using FluentValidation.Results;
using LT.DigitalOffice.DashboardService.Business.User.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.DashboardUser;
using LT.DigitalOffice.DashboardService.Validation.DashboardUser.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Extensions;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.User;

public class CreateDashboardUsersCommand : ICreateDashboardUsersCommand
{
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IAccessValidator _accessValidator;
  private readonly ICreateDashboardUsersValidator _validator;
  private readonly IDbDashboardUserMapper _mapper;
  private readonly IDashboardUserRepository _repository;
  private readonly IResponseCreator _responseCreator;
  //private readonly IPublish _publish;
  
  public CreateDashboardUsersCommand(      
    IHttpContextAccessor httpContextAccessor,
    IAccessValidator accessValidator,
    ICreateDashboardUsersValidator validator,
    IDbDashboardUserMapper mapper,
    IDashboardUserRepository repository,
    IResponseCreator responseCreator)
    //IPublish publish)
  {
    _httpContextAccessor = httpContextAccessor;
    _accessValidator = accessValidator;
    _validator = validator;
    _mapper = mapper;
    _repository = repository;
    _responseCreator = responseCreator;
    //_publish = publish;
  }
  
  public async Task<OperationResultResponse<bool>> ExecuteAsync(CreateDashboardUsersRequest request)
  {

    Guid userId = _httpContextAccessor.HttpContext.GetUserId();

    if (!await _accessValidator.IsAdminAsync(userId))
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
    }

    ValidationResult validationResult = await _validator.ValidateAsync(request);

    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<bool>(
        HttpStatusCode.BadRequest,
        validationResult.Errors.Select(validationFailure => validationFailure.ErrorMessage).ToList());
    }

    List<DbDashboardUser> dbDashboardUsers = request.Users
      .Select(u => _mapper.Map(u, request.DashboardId)).ToList();

    await _repository.CreateAsync(dbDashboardUsers.ToList());

    _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;

    // TODO: уточнить
    //await _publish.UpdateDashboardUserDataAsync(
    //  usersData: dbDashboardUsers.ConvertAll(du => new DashboardUserPublishData(
    //    userId: du.UserId,
    //    DashboardId: du.DashboardId,
    //    role: (DashboardUserRole)du.Role,
    //    assignment: (DashboardUserAssignment)du.Assignment,
    //    isActive: du.IsActive)),
    //  modifiedBy: senderId);

    return new OperationResultResponse<bool>(body: true);
  }
}