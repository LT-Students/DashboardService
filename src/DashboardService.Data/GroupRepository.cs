using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group.Filters;

namespace LT.DigitalOffice.DashboardService.Data;

public class GroupRepository : IGroupRepository
{
  public Task<Guid?> CreateAsync(DbGroup dbDepartment)
  {
    throw new NotImplementedException();
  }

  public Task<DbGroup> GetAllAsync(GetGroupsFilter filter)
  {
    throw new NotImplementedException();
  }

  public Task<DbGroup> GetAsync(Guid id, GetGroupFilter filter)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditAsync(Guid id, JsonPatchDocument<DbGroup> request)
  {
    throw new NotImplementedException();
  }

  public Task<bool> RemoveAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}