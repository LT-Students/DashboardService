using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbTaskMapper : IDbTaskMapper
{
  public DbTask Map(Guid createdBy, CreateTaskRequest request)
  {
    return new()
      {
        Id = Guid.NewGuid(),
        GroupId = request.GroupId,
        TaskTypeId = request.TaskTypeId,
        PriorityId = request.PriorityId,
        Name = request.Name,
        Content = request.Content,
        CreatedAtUtc = DateTime.UtcNow,
        CreatedBy = createdBy,
        DeadlineAtUtc = request.DeadlineAtUtc
      };
  }
}