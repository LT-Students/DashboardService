using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;

[AutoInject]
public interface IDeleteTaskTypeCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id);
}