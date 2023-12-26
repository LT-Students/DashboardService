using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType;

public class GetTaskTypeCommand : IGetTaskTypeCommand
{
  private readonly ITaskTypeRepository _repository;
  
  public GetTaskTypeCommand(ITaskTypeRepository repository) 
  {
    _repository = repository;
  }
  
  public Task<OperationResultResponse<TaskTypeInfo>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}