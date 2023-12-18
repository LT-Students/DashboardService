using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;
using System;

namespace LT.DigitalOffice.DashboardService.Business.ChangeLog.Interfaces;

public interface IRemoveChangeLogCommand
{
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id);
}
