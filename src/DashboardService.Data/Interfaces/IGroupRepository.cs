using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface IGroupRepository
{
  Task<Guid?> CreateAsync(DbGroup dbDepartment);
  Task<IEnumerable<DbGroup>> GetAllAsync();
  Task<DbGroup> GetAsync(Guid id);
  Task<bool> EditAsync(Guid id);
  Task<bool> DeleteAsync(Guid id);
}