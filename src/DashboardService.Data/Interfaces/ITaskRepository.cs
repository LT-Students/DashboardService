using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface ITaskRepository
{
  Task<Guid?> CreateAsync(DbTask dbDepartment);
  Task<List<DbTask>> GetAllAsync();
  Task<DbTask> GetAsync(Guid id);
  Task<bool> EditAsync(Guid id);
  Task<bool> DeleteAsync(Guid id);
}