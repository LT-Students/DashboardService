using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;

public interface IDeleteTaskTypeCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id);
}