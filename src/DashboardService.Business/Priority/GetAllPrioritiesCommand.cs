using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class GetAllPrioritiesCommand : IGetAllPrioritiesCommand
{
  private readonly PriorityRepository _priorityRepository;

  public GetAllPrioritiesCommand(PriorityRepository priorityRepository)
  {
    _priorityRepository = priorityRepository;
  }
  
  public Task<FindResultResponse<IEnumerable<PriorityInfo>>> ExecuteAsync()
  {
    throw new NotImplementedException();
  }
}