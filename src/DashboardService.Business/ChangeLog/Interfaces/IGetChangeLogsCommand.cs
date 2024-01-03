using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;

[AutoInject]
public interface IGetChangeLogsCommand
{
  Task<FindResultResponse<ChangeLogInfo>> ExecuteAsync(GetChangeLogsFilter filter, CancellationToken ct);
}
