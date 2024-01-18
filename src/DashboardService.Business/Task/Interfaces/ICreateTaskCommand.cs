using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task.Interfaces;

[AutoInject]
public interface ICreateTaskCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateTaskRequest request, CancellationToken ct);
}