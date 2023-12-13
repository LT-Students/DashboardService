using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class CreatePriorityCommand : ICreatePriorityCommand
{
  private readonly PriorityRepository _priorityRepository;

  public CreatePriorityCommand(PriorityRepository priorityRepository)
  {
    _priorityRepository = priorityRepository;
  }
  
  public Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePriorityRequest request)
  {
    throw new NotImplementedException();
  }
}