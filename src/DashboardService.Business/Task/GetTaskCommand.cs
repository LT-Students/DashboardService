using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task;

public class GetTaskCommand : IGetTaskCommand
{
  private readonly ITaskRepository _taskRepository;
  private readonly IResponseCreator _responseCreator;

  public GetTaskCommand(
    ITaskRepository taskRepository,
    IResponseCreator responseCreator)
  {
    _taskRepository = taskRepository;
    _responseCreator = responseCreator;
  }
  
  public async Task<OperationResultResponse<TaskResponse>> ExecuteAsync(Guid id, GetTaskFilter filter, CancellationToken cancellationToken)
  {
    DbTask dbTask = await _taskRepository.GetAsync(id, filter, cancellationToken);

    if (dbTask is null)
    {
      return _responseCreator.CreateFailureResponse<TaskResponse>(HttpStatusCode.NotFound);
    }

    // TODO: make mappers
    //return new() {Body = _priorityInfoMapper.Map(dbPriority)};
    
    throw new NotImplementedException();
  }
}