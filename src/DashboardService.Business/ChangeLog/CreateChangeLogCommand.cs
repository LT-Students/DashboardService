using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog;

public class CreateChangeLogCommand : ICreateChangeLogCommand
{
  private readonly IChangeLogRepository _repository;
  private readonly IDbChangeLogMapper _dbChangeLogMapper;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IResponseCreator _responseCreator;
  private readonly IAccessValidator _accessValidator;

  public CreateChangeLogCommand(
    IChangeLogRepository repository,
    IHttpContextAccessor httpContextAccessor,
    IDbChangeLogMapper dbChangeLogMapper,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator)
  {
    _repository = repository;
    _httpContextAccessor = httpContextAccessor;
    _dbChangeLogMapper = dbChangeLogMapper;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
  }

  public Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateChangeLogRequest request)
  {
    throw new NotImplementedException();
  }
}
