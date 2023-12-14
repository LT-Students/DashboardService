using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;

public interface IGetTaskTypeCommand
{
  Task<OperationResultResponse<TaskTypeResponse>> ExecuteAsync(Guid id);
}