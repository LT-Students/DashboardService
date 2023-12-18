using LT.DigitalOffice.DashboardService.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface IChangeLogRepository
{
  Task<Guid?> CreateAsync(DbChangeLog board);

  Task<IEnumerable<DbChangeLog>> GetAllAsync();

  Task<DbChangeLog> GetAsync(Guid id);

  Task<bool> EditAsync(Guid id);

  Task<bool> RemoveAsync(Guid id);
}
