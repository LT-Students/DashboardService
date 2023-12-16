using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface ICommentRepository
{
  Task<Guid?> CreateAsync(DbComment dbDepartment);
  Task<IEnumerable<DbComment>> GetAllAsync();
  Task<DbComment> GetAsync(Guid id);
  Task<bool> EditAsync(Guid id);
  Task<bool> DeleteAsync(Guid id);
}