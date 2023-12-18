using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;

namespace LT.DigitalOffice.DashboardService.Mappers.Models;

public class TaskInfoMapper : ITaskInfoMapper
{
  public TaskInfo Map(DbTask dbTask)
  {
    return dbTask is null
      ? null
      : new()
      {
        Id = dbTask.Id,
        TaskTypeId = dbTask.TaskTypeId,
        PriorityId = dbTask.PriorityId,
        Name = dbTask.Name,
        Content = dbTask.Content,
        CreatedAtUtc = dbTask.CreatedAtUtc,
        DeadlineAtUtc = dbTask.DeadlineAtUtc
      };
  }
}