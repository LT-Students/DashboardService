using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class EditPriorityCommand : IEditPriorityCommand
{
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, PatchPriorityRequest request)
  {
    throw new NotImplementedException();
  }
}