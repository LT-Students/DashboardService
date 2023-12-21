using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task;

public class GetTaskCommand : IGetTaskCommand
{
  private readonly ITaskRepository _taskRepository;

  public GetTaskCommand(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }
  
  public Task<OperationResultResponse<TaskResponse>> ExecuteAsync(Guid id, GetTaskFilter filter)
  {
    throw new NotImplementedException();
  }
}