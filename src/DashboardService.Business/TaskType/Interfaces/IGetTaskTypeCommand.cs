using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;

[AutoInject]
public interface IGetTaskTypeCommand
{
  Task<OperationResultResponse<TaskTypeInfo>> ExecuteAsync(Guid id, CancellationToken ct);
}