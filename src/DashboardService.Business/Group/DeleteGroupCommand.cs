using LT.DigitalOffice.DashboardService.Business.Group.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group;

public class DeleteGroupCommand : IDeleteGroupCommand
{
  private readonly IGroupRepository _repository;

  public DeleteGroupCommand(IGroupRepository repository)
  {
    _repository = repository;
  }

  public Task<OperationResultResponse<bool>> ExecuteAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}