using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.DashboardService.Models.Db;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface IBoardRepository
{
  Task CreateAsync(DbBoard board);

  Task<List<DbBoard>> GetAllAsync();

  Task<DbBoard> GetAsync(Guid id);

  Task<bool> EditByIdAsync(Guid id, JsonPatchDocument<DbChangeLog> dbChangeLog);

  Task<bool> RemoveAsync(Guid id);
}
