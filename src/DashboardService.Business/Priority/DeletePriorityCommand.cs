using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class DeletePriorityCommand : IDeletePriorityCommand
{
  private readonly PriorityRepository _priorityRepository;

  public DeletePriorityCommand(PriorityRepository priorityRepository)
  {
    _priorityRepository = priorityRepository;
  }
  
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}