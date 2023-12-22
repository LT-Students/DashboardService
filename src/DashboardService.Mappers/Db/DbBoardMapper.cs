using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;

using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbBoardMapper : IDbBoardMapper
{
  public DbBoard Map(CreateBoardRequest request, Guid createdById)
  {
    return new()
    {
      Id = Guid.NewGuid(),
      ProjectId = request.ProjectId,
      Name = request.Name,
      IsActive = true,
      CreatedBy = createdById,
      CreatedAtUtc = DateTime.UtcNow,
    };
  }
}
