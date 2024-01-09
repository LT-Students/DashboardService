using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;

[AutoInject]
public interface IEditTaskTypeCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<EditTaskTypeRequest> request, CancellationToken ct);
}