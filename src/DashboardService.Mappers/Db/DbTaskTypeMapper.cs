using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.TaskType;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbTaskTypeMapper : IDbTaskTypeMapper
{
  public DbTaskType Map(CreateTaskTypeRequest request)
  {
    return request is null
      ? null
      : new()
      {
        Id = Guid.NewGuid(), 
        Name = request.TaskTypeName
      };
  }
}