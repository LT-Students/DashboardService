using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;

public interface IGetTaskTypeCommand
{
  Task<OperationResultResponse<TaskTypeInfo>> ExecuteAsync(Guid id);
}