using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class RemovePriorityCommand : IRemovePriorityCommand
{
  private readonly IPriorityRepository _priorityRepository;

  public RemovePriorityCommand(IPriorityRepository priorityRepository)
  {
    _priorityRepository = priorityRepository;
  }
  
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}