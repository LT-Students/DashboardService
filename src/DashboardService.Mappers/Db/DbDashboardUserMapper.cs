using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.DashboardUser;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbDashboardUserMapper : IDbDashboardUserMapper
{
  public DbDashboardUser Map(CreateUserRequest request, Guid dashboardId)
  {
    return new DbDashboardUser
      {
        Id = Guid.NewGuid(),
        UserId = request.UserId,
        DashboardId = dashboardId,
      };
  }
}