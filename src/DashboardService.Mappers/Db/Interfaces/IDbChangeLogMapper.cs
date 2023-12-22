using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;
using LT.DigitalOffice.Kernel.Attributes;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbChangeLogMapper
{
  public DbChangeLog Map(CreateChangeLogRequest request, Guid createdById, string propertyOldValue);
}
