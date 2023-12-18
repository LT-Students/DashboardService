using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task.Interfaces;

[AutoInject]
public interface IGetTaskCommand
{
  Task<OperationResultResponse<TaskResponse>> ExecuteAsync(Guid id);
}