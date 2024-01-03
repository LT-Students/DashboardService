using LT.DigitalOffice.DashboardService.Business.Group.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group.Filters;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group;

public class GetGroupCommand : IGetGroupCommand
{
  private readonly IGroupRepository _repository;

  public GetGroupCommand(IGroupRepository repository)
  {
    _repository = repository;
  }

  public Task<OperationResultResponse<GroupResponse>> ExecuteAsync(GetGroupFilter filter, Guid id)
  {
    throw new NotImplementedException();
  }
}