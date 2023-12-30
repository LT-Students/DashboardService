using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbGroupMapper : IDbGroupMapper
{
  public DbGroup Map(Guid createdBy, CreateGroupRequest request)
  {
    return new()
      {
        Id = Guid.NewGuid(),
        BoardId = request.BoardId,
        Name = request.Name,
        IsActive = request.IsActive,
        CreatedBy = createdBy,
        CreatedAtUtc = DateTime.UtcNow,
      };
  }
}