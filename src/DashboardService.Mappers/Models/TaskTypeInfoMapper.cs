using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;

namespace LT.DigitalOffice.DashboardService.Mappers.Models;

public class TaskTypeInfoMapper : ITaskTypeInfoMapper
{
  public TaskTypeInfo Map(DbTaskType dbTaskType)
  {
    return dbTaskType is null
      ? null
      : new()
      {
        Id = dbTaskType.Id, 
        Name = dbTaskType.Name
      };
  }
}