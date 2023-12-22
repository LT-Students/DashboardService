using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;

[AutoInject]
public interface ICreateTaskTypeCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateTaskTypeRequest request, CancellationToken ct);
}