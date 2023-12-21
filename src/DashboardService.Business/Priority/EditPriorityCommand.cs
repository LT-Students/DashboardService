using LT.DigitalOffice.DashboardService.Business.Priority.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Priority;

public class EditPriorityCommand : IEditPriorityCommand
{
  private readonly IPriorityRepository _priorityRepository;

  public EditPriorityCommand(IPriorityRepository priorityRepository)
  {
    _priorityRepository = priorityRepository;
  }
  
  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<PatchPriorityRequest> request)
  {
    throw new NotImplementedException();
  }
}