using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface ITaskTypeRepository
{
  Task<Guid?> CreateAsync(DbTaskType dbDepartment);
  Task<IEnumerable<DbTaskType>> GetAllAsync();
  Task<DbTaskType> GetAsync(Guid id);
  Task<bool> EditAsync(Guid id);
  Task<bool> DeleteAsync(Guid id);
}