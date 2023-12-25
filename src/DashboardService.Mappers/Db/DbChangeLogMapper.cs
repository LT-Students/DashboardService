using LT.DigitalOffice.DashboardService.Data.Interfaces;
using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbChangeLogMapper : IDbChangeLogMapper
{
  public DbChangeLog Map(CreateChangeLogRequest request, Guid createdById, string propertyOldValue)
  {
    return new()
    {
      Id = Guid.NewGuid(),
      TaskId = request.TaskId,
      CreatedBy = createdById,
      EntityName = request.EntityName,
      PropertyName = request.PropertyName,
      PropertyOldValue = propertyOldValue,
      PropertyNewValue = request.PropertyNewValue,
      CreatedAtUtc = DateTime.UtcNow,
    };
  }
}
