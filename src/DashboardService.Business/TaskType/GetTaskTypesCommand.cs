using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType.Filters;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType;

public class GetTaskTypesCommand : IGetTaskTypesCommand
{
  private readonly ITaskTypeRepository _taskTypeRepository;
  private readonly ITaskTypeInfoMapper _taskTypeInfoMapper;

  public GetTaskTypesCommand(
    ITaskTypeRepository repository,
    ITaskTypeInfoMapper taskTypeInfoMapper)
  {
    _taskTypeRepository = repository;
    _taskTypeInfoMapper = taskTypeInfoMapper;
  }
  
  public async Task<FindResultResponse<TaskTypeInfo>> ExecuteAsync(GetTaskTypesFilter filter, CancellationToken ct)
  {
    (List<DbTaskType> dbTaskTypes, int totalCount) result = await _taskTypeRepository.GetAllAsync(filter, ct);

    return new()
    {
      Body = result.dbTaskTypes.ConvertAll(_taskTypeInfoMapper.Map),
      TotalCount = result.totalCount
    };
  }
}