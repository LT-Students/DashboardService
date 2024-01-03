using LT.DigitalOffice.DashboardService.Business.Group.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group.Filters;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group;

public class GetGroupsCommand : IGetGroupsCommand
{
  private readonly IGroupRepository _repository;

  public GetGroupsCommand(IGroupRepository repository)
  {
    _repository = repository;
  }

  public Task<FindResultResponse<GroupInfo>> ExecuteAsync(GetGroupsFilter filter)
  {
    throw new System.NotImplementedException();
  }
}