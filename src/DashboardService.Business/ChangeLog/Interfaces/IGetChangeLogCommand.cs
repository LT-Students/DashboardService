using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using System;
using LT.DigitalOffice.Kernel.Attributes;
using System.Threading;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;

[AutoInject]
public interface IGetChangeLogCommand
{
  Task<OperationResultResponse<ChangeLogInfo>> ExecuteAsync(Guid id, CancellationToken ct);
}
