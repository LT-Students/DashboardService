using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class DeletePriorityCommand : IDeletePriorityCommand
{
  private readonly IPriorityRepository _priorityRepository;

  public DeletePriorityCommand(IPriorityRepository priorityRepository)
  {
    _priorityRepository = priorityRepository;
  }
  
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}