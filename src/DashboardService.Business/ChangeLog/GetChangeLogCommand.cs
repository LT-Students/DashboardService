using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog;

public class GetChangeLogCommand : IGetChangeLogCommand
{
  private readonly IChangeLogRepository _repository;
  private readonly IResponseCreator _responseCreator;
  private readonly IChangeLogResponseMapper _changeLogResponseMapper;

  public GetChangeLogCommand(
    IChangeLogRepository repository,
    IChangeLogResponseMapper changeLogResponseMapper,
    IResponseCreator responseCreator)
  {
    _repository = repository;
    _changeLogResponseMapper = changeLogResponseMapper;
    _responseCreator = responseCreator;
  }

  public Task<OperationResultResponse<ChangeLogResponse>> ExecuteAsync(Guid id, GetChangeLogFilter filter)
  {
    throw new NotImplementedException();
  }
}
