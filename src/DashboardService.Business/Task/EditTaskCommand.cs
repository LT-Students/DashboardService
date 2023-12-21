using LT.DigitalOffice.DashboardService.Business.Task.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Task;

public class EditTaskCommand : IEditTaskCommand
{
  private readonly ITaskRepository _taskRepository;

  public EditTaskCommand(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }
  
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<PatchTaskRequest> request)
  {
    throw new NotImplementedException();
  }
}