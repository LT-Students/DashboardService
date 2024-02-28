using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Data.Interfaces;

[AutoInject]
public interface IDashboardUserRepository
{
  Task<bool> CreateAsync(List<DbDashboardUser> dasbhoardUsers);
}