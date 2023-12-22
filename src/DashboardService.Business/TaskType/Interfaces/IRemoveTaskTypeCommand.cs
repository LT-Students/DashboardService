using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;

[AutoInject]
public interface IRemoveTaskTypeCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, CancellationToken ct);
}