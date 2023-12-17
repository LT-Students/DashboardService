using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.EFSupport.Provider;
using LT.DigitalOffice.Kernel.Enums;
using Microsoft.EntityFrameworkCore;

namespace LT.DigitalOffice.DashboardService.Data.Provider;

[AutoInject(InjectType.Scoped)]
public interface IDataProvider : IBaseDataProvider
{
  DbSet<DbBoard> Boards { get; set; }
  DbSet<DbChangeLog> ChangeLogs { get; set; }
  DbSet<DbComment> Comments { get; set; }
  DbSet<DbGroup> Groups { get; set; }
  DbSet<DbPriority> Priorities { get; set; }
  DbSet<DbTask> Tasks { get; set; }
  DbSet<DbTaskType> TaskTypes { get; set; }
}