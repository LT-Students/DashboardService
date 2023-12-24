using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;

namespace LT.DigitalOffice.DashboardService.Mappers.Models;

public class PriorityInfoMapper : IPriorityInfoMapper
{
  public PriorityInfo Map(DbPriority dbPriority)
  {
    return new()
      {
        Id = dbPriority.Id, 
        Name = dbPriority.Name
      };
  }
}