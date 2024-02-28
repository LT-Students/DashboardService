using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.DashboardUser;
using LT.DigitalOffice.Kernel.Attributes;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbDashboardUserMapper
{
  DbDashboardUser Map(CreateUserRequest request, Guid departmentId);
}