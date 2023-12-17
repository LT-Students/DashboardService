using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class GetPrioritiesCommand : IGetPrioritiesCommand
{
  private readonly IPriorityRepository _priorityRepository;

  public GetPrioritiesCommand(IPriorityRepository priorityRepository)
  {
    _priorityRepository = priorityRepository;
  }
  
  public Task<FindResultResponse<PriorityInfo>> ExecuteAsync()
  {
    throw new NotImplementedException();
  }
}