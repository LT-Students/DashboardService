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
  private readonly IHttpContextAccessor _httpContextAccessor;

  public DbGroupMapper(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

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
        CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
        CreatedAtUtc = DateTime.UtcNow,
        ModifiedBy = _httpContextAccessor.HttpContext.GetUserId(),
        ModifiedAtUtc = DateTime.UtcNow
      };
  }
}