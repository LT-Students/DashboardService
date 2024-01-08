using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog;

public class GetChangeLogCommand : IGetChangeLogCommand
{
  private readonly IChangeLogRepository _repository;
  private readonly IResponseCreator _responseCreator;
  private readonly IChangeLogInfoMapper _changeLogInfoMapper;

  public GetChangeLogCommand(
    IChangeLogRepository repository,
    IChangeLogInfoMapper changeLogInfoMapper,
    IResponseCreator responseCreator)
  {
    _repository = repository;
    _changeLogInfoMapper = changeLogInfoMapper;
    _responseCreator = responseCreator;
  }

  public async Task<OperationResultResponse<ChangeLogInfo>> ExecuteAsync(Guid changeLogId, CancellationToken ct)
  {
    DbChangeLog dbChange = await _repository.GetAsync(changeLogId, ct);

    if (dbChange is null)
    {
      return _responseCreator.CreateFailureResponse<ChangeLogInfo>(HttpStatusCode.NotFound);
    }

    return new OperationResultResponse<ChangeLogInfo>(
      body: _changeLogInfoMapper.Map(dbChange));
  }
}
