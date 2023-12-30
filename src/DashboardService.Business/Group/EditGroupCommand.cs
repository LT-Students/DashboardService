using LT.DigitalOffice.DashboardService.Business.Group.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group;

public class EditGroupCommand : IEditGroupCommand
{
  private readonly IGroupRepository _repository;

  public EditGroupCommand(IGroupRepository repository)
  {
    _repository = repository;
  }

  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id, JsonPatchDocument<EditGroupRequest> request)
  {
    throw new NotImplementedException();
  }
}