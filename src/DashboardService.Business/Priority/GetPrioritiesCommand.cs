using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority.Filters;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class GetPrioritiesCommand : IGetPrioritiesCommand
{
  private readonly IPriorityRepository _priorityRepository;

  public GetPrioritiesCommand(IPriorityRepository priorityRepository)
  {
    _priorityRepository = priorityRepository;
  }
  
  public Task<FindResultResponse<PriorityInfo>> ExecuteAsync(GetPrioritiesFilter filter)
  {
    throw new NotImplementedException();
  }
}