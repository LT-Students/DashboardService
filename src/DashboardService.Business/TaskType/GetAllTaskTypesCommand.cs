using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType;

public class GetAllTaskTypesCommand : IGetAllTaskTypesCommand
{
  private readonly ITaskTypeRepository _repository;
  
  public GetAllTaskTypesCommand(ITaskTypeRepository repository) 
  {
    _repository = repository;
  }
  
  public Task<FindResultResponse<IEnumerable<TaskTypeInfo>>> ExecuteAsync()
  {
    throw new System.NotImplementedException();
  }
}