using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbTaskMapper : IDbTaskMapper
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public DbTaskMapper(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }
  
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
        CreatedAtUtc = DateTime.UtcNow,
        CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
        DeadlineAtUtc = request.DeadlineAtUtc
      };
  }
}