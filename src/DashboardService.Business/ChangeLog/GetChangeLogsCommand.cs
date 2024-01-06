using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog;

public class GetChangeLogsCommand : IGetChangeLogsCommand
{
  private readonly IChangeLogRepository _repository;
  private readonly IChangeLogInfoMapper _changeLogInfoMapper;

  public GetChangeLogsCommand(
    IChangeLogRepository repository,
    IChangeLogInfoMapper changeLogInfoMapper)
  {
    _repository = repository;
    _changeLogInfoMapper = changeLogInfoMapper;
  }

  public async Task<FindResultResponse<ChangeLogInfo>> ExecuteAsync(GetChangeLogsFilter filter, CancellationToken ct)
  {
    (List<DbChangeLog> dbChanges, int totalCount) = await _repository.GetChangeLogsAsync(filter, ct);

    if (dbChanges is null || !dbChanges.Any())
    {
      return new()
      {
        Body = new List<ChangeLogInfo>(),
      };
    }

    return new()
    {
      Body = dbChanges.ConvertAll(_changeLogInfoMapper.Map),
      TotalCount = totalCount
    };
  }
}
