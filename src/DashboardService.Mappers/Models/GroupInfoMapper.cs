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
    var dataTime = DateTime.UtcNow;
    var httpAccessorUserId = _httpContextAccessor.HttpContext.GetUserId();
    return dbGroup is null
      ? null
      : new()
      {
        Id = dbGroup.Id,
        BoardId = dbGroup.BoardId,
        Name = dbGroup.Name,
        IsActive = dbGroup.IsActive,
        CreatedBy = httpAccessorUserId,
        CreatedAtUtc = dataTime,
        ModifiedBy = httpAccessorUserId,
        ModifiedAtUtc = dataTime
      };
  }
}