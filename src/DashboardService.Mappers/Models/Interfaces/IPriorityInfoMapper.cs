using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;

namespace LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;

public interface IPriorityInfoMapper
{
  PriorityInfo Map(DbPriority dbPriority);
}