using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;

[AutoInject]
public interface IRemoveChangeLogCommand
{
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id);
}
