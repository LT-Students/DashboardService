using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbChangeLogMapper : IDbChangeLogMapper
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  // TODO
  // How to set a value on PropertyOldValue ?

  private readonly IChangeLogRepository _repository;

  public DbChangeLogMapper(IHttpContextAccessor httpContextAccessor, IChangeLogRepository repository)
  {
    _httpContextAccessor = httpContextAccessor;
    _repository = repository;
  }

  public DbChangeLog Map(CreateChangeLogRequest request)
  {
    return request is null
      ? null
      : new()
      {
        Id = Guid.NewGuid(),
        TaskId = request.TaskId,
        CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
        EntityName = request.EntityName,
        PropertyName = request.PropertyName,
        //PropertyOldValue = _repository.GetLogByLastChange(request.TaskId).PropertyOldValue,
        PropertyNewValue = request.PropertyNewValue,
        CreatedAtUtc = DateTime.UtcNow,
      };
  }
}
