using LT.DigitalOffice.DashboardService.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

public interface IChangeLogRepository
{
  Task<Guid?> CreateAsync(DbChangeLog board);

  Task<IEnumerable<DbChangeLog>> GetAllAsync();

  Task<DbChangeLog> GetAsync(Guid id);

  Task<bool> EditAsync(Guid id);

  Task<bool> RemoveAsync(Guid id);
}
