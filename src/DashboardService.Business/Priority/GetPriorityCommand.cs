using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class GetPriorityCommand : IGetPriorityCommand
{
  private readonly PriorityRepository _priorityRepository;

  public GetPriorityCommand(PriorityRepository priorityRepository)
  {
    _priorityRepository = priorityRepository;
  }
  
  public Task<OperationResultResponse<PriorityResponse>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}