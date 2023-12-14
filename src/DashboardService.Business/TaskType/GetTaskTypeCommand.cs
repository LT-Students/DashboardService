using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
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
  
  public Task<OperationResultResponse<TaskTypeResponse>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}