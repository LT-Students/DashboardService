using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;

[AutoInject]
public interface IEditPriorityCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, PatchPriorityRequest request);
}