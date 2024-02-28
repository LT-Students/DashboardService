using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface IGroupRepository
{
  Task<Guid?> CreateAsync(DbGroup dbGroup);
  Task<DbGroup> GetAllAsync(GetGroupsFilter filter);
  Task<DbGroup> GetAsync(Guid id, GetGroupFilter filter);
  Task<bool> EditAsync(Guid id, JsonPatchDocument<DbGroup> request);
  Task<bool> RemoveAsync(Guid id);
}