using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db
{
  public class DbBoardMapper : IDbBoardMapper
  {
    /// <summary>
    /// ????????????????
    /// </summary>
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbBoardMapper(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public DbBoard Map(CreateBoardRequest request)
    {
      return request is null
        ? null
        : new()
        {
          Id = Guid.NewGuid(),
          ProjectId = request.ProjectId,
          Name = request.Name,
          IsActive = true,
          CreatedBy = request.CreatedBy, // _httpContextAccessor.HttpContext.GetUserId() ?????
          CreatedAtUtc = DateTime.UtcNow,
        };
    }
  }
}
