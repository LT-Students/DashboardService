using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;

[AutoInject]
public interface ICreateChangeLogCommand
{
  public Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateChangeLogRequest request);
}
