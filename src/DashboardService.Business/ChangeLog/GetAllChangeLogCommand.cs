using LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog;

public class GetAllChangeLogCommand : IGetAllChangeLogsCommand
{
  private readonly IChangeLogRepository _repository;

  public GetAllChangeLogCommand(IChangeLogRepository repository)
  {
    _repository = repository;
  }

  public Task<FindResultResponse<ChangeLogInfo>> ExecuteAsync(GetChangeLogsFilter filter)
  {
    throw new System.NotImplementedException();
  }
}
