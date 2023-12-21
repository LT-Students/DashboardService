using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using System;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;

[AutoInject]
public interface IGetChangeLogCommand
{
  public Task<OperationResultResponse<ChangeLogResponse>> ExecuteAsync(Guid id, GetChangeLogFilter filter);
}
