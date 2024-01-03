using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog;

public class GetChangeLogsCommand : IGetChangeLogsCommand
{
  private readonly IChangeLogRepository _repository;
  private readonly IResponseCreator _responseCreator;
  private readonly IChangeLogInfoMapper _changeLogInfoMapper;

  public GetChangeLogsCommand(
    IChangeLogRepository repository,
    IResponseCreator responseCreator,
    IChangeLogInfoMapper changeLogInfoMapper)
  {
    _repository = repository;
    _responseCreator = responseCreator;
    _changeLogInfoMapper = changeLogInfoMapper;
  }

  public Task<FindResultResponse<ChangeLogInfo>> ExecuteAsync(GetChangeLogsFilter filter, CancellationToken ct)
  {
    throw new System.NotImplementedException();
  }
}
