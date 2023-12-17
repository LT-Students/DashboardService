using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType;

public class GetTaskTypesCommand : IGetTaskTypesCommand
{
  private readonly ITaskTypeRepository _repository;
  
  public GetTaskTypesCommand(ITaskTypeRepository repository) 
  {
    _repository = repository;
  }
  
  public Task<FindResultResponse<TaskTypeInfo>> ExecuteAsync()
  {
    throw new System.NotImplementedException();
  }
}