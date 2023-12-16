using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbGroupMapper : IDbGroupMapper
{
  public DbGroup Map(CreateGroupRequest request)
  {
    return request is null
      ? null
      : new()
      {
        Id = Guid.NewGuid(),
        BoardId = request.BoardId,
        Name = request.GroupName,
        IsActive = request.GroupIsActive,
        CreatedBy = request.GroupCreatedBy,
        CreatedAtUtc = request.GroupCreatedAtUtc,
        ModifiedBy = request.GroupModifiedBy,
        ModifiedAtUtc = request.GroupModifiedAtUtc
      };
  }
}