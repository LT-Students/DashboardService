using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;

[AutoInject]
public interface IPriorityInfoMapper
{
  PriorityInfo Map(DbPriority dbPriority);
}