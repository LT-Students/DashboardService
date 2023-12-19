using LT.DigitalOffice.DashboardService.Business.Group.Interfaces;
using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Business.Group;

public class GetAllGroupsCommand : IGetAllGroupsCommand
{
  private readonly IGroupRepository _repository;

  public GetAllGroupsCommand(IGroupRepository repository)
  {
    _repository = repository;
  }

  public Task<FindResultResponse<GroupInfo>> ExecuteAsync()
  {
    throw new System.NotImplementedException();
  }
}