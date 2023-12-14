using LT.DigitalOffice.DashboardService.Business.TaskType.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.TaskType;

public class DeleteTaskTypeCommand : IDeleteTaskTypeCommand
{
  private readonly ITaskTypeRepository _repository;

  public DeleteTaskTypeCommand(ITaskTypeRepository repository)
  {
    _repository = repository;
  }
  
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}