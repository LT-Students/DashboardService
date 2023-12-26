using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbPriorityMapper : IDbPriorityMapper
{
  public DbPriority Map(CreatePriorityRequest request)
  {
    return request is null
      ? null
      : new()
      {
        Id = Guid.NewGuid(), 
        Name = request.Name
      };
  }
}