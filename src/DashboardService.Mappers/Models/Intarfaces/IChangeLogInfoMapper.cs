using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;

namespace LT.DigitalOffice.DashboardService.Mappers.Models.Intarfaces;

public interface IChangeLogInfoMapper
{
  ChangeLogInfo Map(DbChangeLog dbChangeLog);
}
