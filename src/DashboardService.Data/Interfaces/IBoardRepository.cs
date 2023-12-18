using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.DashboardService.Models.Db;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface IBoardRepository
{
  Task CreateAsync(DbBoard board);

  Task<IEnumerable<DbBoard>> GetAllAsync();

  Task<DbBoard> GetAsync(Guid id);

  Task<bool> EditByIdAsync(Guid id);

  Task<bool> RemoveAsync(Guid id);
}
