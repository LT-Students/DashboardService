using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using LT.DigitalOffice.DashboardService.Models.Dto.Responces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog;

public class GetChangeLogCommand : IGetChangeLogCommand
{
  private readonly IChangeLogRepository _repository;

  public GetChangeLogCommand(IChangeLogRepository repository)
  {
    _repository = repository;
  }

  public Task<OperationResultResponse<ChangeLogResponse>> ExecuteAsync(Guid id, GetChangeLogFilter filter)
  {
    throw new NotImplementedException();
  }
}
