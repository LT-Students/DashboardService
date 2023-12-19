using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface IPriorityRepository
{
  Task<Guid?> CreateAsync(DbPriority dbDepartment);
  Task<List<DbPriority>> GetAllAsync();
  Task<DbPriority> GetAsync(Guid id);
  Task<bool> EditAsync(Guid id, JsonPatchDocument<DbPriority> request);
  Task<bool> RemoveAsync(Guid id);
}