using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Mappers.Models.Intarfaces;

[AutoInject]
public interface IChangeLogInfoMapper
{
  ChangeLogInfo Map(DbChangeLog dbChangeLog);
}
