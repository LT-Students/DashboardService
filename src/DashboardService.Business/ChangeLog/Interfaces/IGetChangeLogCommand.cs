using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;
using LT.DigitalOffice.DashboardService.Models.Dto.Responces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;
using System;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;

public interface IGetChangeLogCommand
{
  public Task<OperationResultResponse<ChangeLogResponce>> ExecuteAsync(Guid id, GetChangeLogFilter filter);
}
