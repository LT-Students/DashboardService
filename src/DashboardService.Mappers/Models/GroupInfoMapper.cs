using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Models;

public class GroupInfoMapper : IGroupInfoMapper
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public GroupInfoMapper(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

  public GroupInfo Map(DbGroup dbGroup)
  {
    return dbGroup is null
      ? null
      : new()
      {
        Id = dbGroup.Id,
        BoardId = dbGroup.BoardId,
        Name = dbGroup.Name,
        IsActive = dbGroup.IsActive,
        CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
        CreatedAtUtc = DateTime.UtcNow,
        ModifiedBy = _httpContextAccessor.HttpContext.GetUserId(),
        ModifiedAtUtc = DateTime.UtcNow
      };
  }
}