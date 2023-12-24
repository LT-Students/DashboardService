using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task;

public class GetTasksCommand : IGetTasksCommand
{
  private readonly ITaskRepository _priorityRepository;
  private readonly ITaskInfoMapper _taskInfoMapper;

  public GetTasksCommand(
    ITaskRepository priorityRepository,
    ITaskInfoMapper taskInfoMapper)
  {
    _priorityRepository = priorityRepository;
    _taskInfoMapper = taskInfoMapper;
  }
  
  public async Task<FindResultResponse<TaskInfo>> ExecuteAsync(GetTasksFilter filter, CancellationToken cancellationToken)
  {
    (List<DbTask> dbTasks, int totalCount) result = await _priorityRepository.GetAllAsync(filter, cancellationToken);

    return new()
    {
      Body = result.dbTasks.Select(p => _taskInfoMapper.Map(p)).ToList(), TotalCount = result.totalCount
    };
  }
}