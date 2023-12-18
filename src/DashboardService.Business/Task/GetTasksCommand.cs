using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task;

public class GetTasksCommand : IGetTasksCommand
{
  private readonly ITaskRepository _priorityRepository;

  public GetTasksCommand(ITaskRepository priorityRepository)
  {
    _priorityRepository = priorityRepository;
  }
  
  public Task<FindResultResponse<TaskInfo>> ExecuteAsync()
  {
    throw new NotImplementedException();
  }
}