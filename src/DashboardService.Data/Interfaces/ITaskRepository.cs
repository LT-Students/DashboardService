using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface ITaskRepository
{
  Task<Guid?> CreateAsync(DbTask dbDepartment);
  Task<List<DbTask>> GetAllAsync(GetTasksFilter filter);
  Task<DbTask> GetAsync(Guid id, GetTaskFilter filter);
  Task<bool> EditAsync(Guid id, JsonPatchDocument<DbTask> request);
  Task<bool> RemoveAsync(Guid id);
}