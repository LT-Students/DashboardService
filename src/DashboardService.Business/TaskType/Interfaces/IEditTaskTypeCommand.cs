using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;

public interface IEditTaskTypeCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<PatchTaskTypeRequest> request);
}