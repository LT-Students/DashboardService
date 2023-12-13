using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class FindPriorityCommand : IFindPriorityCommand
{
  public Task<OperationResultResponse<PriorityInfo>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}