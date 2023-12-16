using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Models;

public class GroupInfoMapper : IGroupInfoMapper
{
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
        CreatedBy = dbGroup.CreatedBy,
        CreatedAtUtc = dbGroup.CreatedAtUtc,
        ModifiedBy = dbGroup.ModifiedBy,
        ModifiedAtUtc = dbGroup.ModifiedAtUtc
      };
  }
}