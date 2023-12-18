using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task.Interfaces;

public interface IDeleteTaskCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid id);
}