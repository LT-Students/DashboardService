using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbTaskMapper : IDbTaskMapper
{
  public DbTask Map(CreateTaskRequest request)
  {
    return request is null
      ? null
      : new()
      {
        Id = Guid.NewGuid(),
        GroupId = request.GroupId,
        TaskTypeId = request.TaskTypeId,
        PriorityId = request.PriorityId,
        Name = request.Name,
        Content = request.Content,
        CreatedAtUtc = DateTime.Now,
        DeadlineAtUtc = request.DeadlineAtUtc
      };
  }
}