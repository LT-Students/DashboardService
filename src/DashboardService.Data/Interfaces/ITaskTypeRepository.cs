using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface ITaskTypeRepository
{
  Task<Guid?> CreateAsync(DbTaskType dbDepartment);
  Task<List<DbTaskType>> GetAllAsync(GetTaskTypesFilter filter);
  Task<DbTaskType> GetAsync(Guid id);
  Task<bool> EditAsync(Guid id, JsonPatchDocument<DbTaskType> request);
  Task<bool> RemoveAsync(Guid id);
}