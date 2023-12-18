using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbBoardMapper : IDbBoardMapper
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public DbBoardMapper(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

  public DbBoard Map(CreateBoardRequest request)
  {
    return new()
    {
      Id = Guid.NewGuid(),
      ProjectId = request.ProjectId,
      Name = request.Name,
      IsActive = true,
      CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
      CreatedAtUtc = DateTime.UtcNow,
    };
  }
}
