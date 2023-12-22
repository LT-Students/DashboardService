using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType;

public class GetTaskTypeCommand : IGetTaskTypeCommand
{
  private readonly ITaskTypeRepository _taskTypeRepository;
  private readonly IResponseCreator _responseCreator;
  private readonly ITaskTypeInfoMapper _taskTypeInfoMapper;

  public GetTaskTypeCommand(
    ITaskTypeRepository repository,
    IResponseCreator responseCreator,
    ITaskTypeInfoMapper taskTypeInfoMapper)
  {
    _taskTypeRepository = repository;
    _responseCreator = responseCreator;
    _taskTypeInfoMapper = taskTypeInfoMapper;
  }
  
  public async Task<OperationResultResponse<TaskTypeInfo>> ExecuteAsync(Guid id, CancellationToken ct)
  {
    DbTaskType dbPriority = await _taskTypeRepository.GetAsync(id, ct);

    if (dbPriority is null)
    {
      return _responseCreator.CreateFailureResponse<TaskTypeInfo>(HttpStatusCode.NotFound);
    }

    return new()
    {
      Body = _taskTypeInfoMapper.Map(dbPriority)
    };
  }
}