using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task;

public class DeleteTaskCommand : IDeleteTaskCommand
{
  private readonly ITaskRepository _taskRepository;

  public DeleteTaskCommand(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }
  
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}