using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;

namespace LT.DigitalOffice.DashboardService.Mappers.Models;

public class ChangeLogInfoMapper : IChangeLogInfoMapper
{
  public ChangeLogInfo Map(DbChangeLog dbChangeLog)
  {
    return new()
    {
      Id = dbChangeLog.Id,
      CreatedBy = dbChangeLog.CreatedBy,
      EntityName = dbChangeLog.EntityName,
      PropertyName = dbChangeLog.PropertyName,
      PropertyOldValue = dbChangeLog.PropertyOldValue,
      PropertyNewValue = dbChangeLog.PropertyNewValue,
      CreatedAtUtc = dbChangeLog.CreatedAtUtc,
    };
  }
}
