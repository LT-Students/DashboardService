using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task;

public class GetTasksCommand : IGetTasksCommand
{
  private readonly ITaskRepository _taskRepository;
  private readonly ITaskInfoMapper _taskInfoMapper;

  public GetTasksCommand(
    ITaskRepository taskRepository,
    ITaskInfoMapper taskInfoMapper)
  {
    _taskRepository = taskRepository;
    _taskInfoMapper = taskInfoMapper;
  }
  
  public async Task<FindResultResponse<TaskInfo>> ExecuteAsync(GetTasksFilter filter, CancellationToken ct)
  {
    (List<DbTask> dbTasks, int totalCount) result = await _taskRepository.GetAllAsync(filter, ct);

    return new()
    {
      Body = result.dbTasks.ConvertAll(_taskInfoMapper.Map), 
      TotalCount = result.totalCount
    };
  }
}