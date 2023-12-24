using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
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
  private readonly ITaskResponseMapper _responseMapper;

  public GetTaskCommand(
    ITaskRepository taskRepository,
    IResponseCreator responseCreator,
    ITaskResponseMapper responseMapper)
  {
    _taskRepository = taskRepository;
    _responseCreator = responseCreator;
    _responseMapper = responseMapper;
  }
  
  public async Task<OperationResultResponse<TaskResponse>> ExecuteAsync(Guid id, GetTaskFilter filter, CancellationToken ct)
  {
    DbTask dbTask = await _taskRepository.GetAsync(id, filter, ct);

    if (dbTask is null)
    {
      return _responseCreator.CreateFailureResponse<TaskResponse>(HttpStatusCode.NotFound);
    }
    
    return new() { Body = _responseMapper.Map(dbTask) };
  }
}