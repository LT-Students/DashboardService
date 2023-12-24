using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbCommentMapper : IDbCommentMapper
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public DbCommentMapper(IHttpContextAccessor httpContextAccessor)
  {
     _httpContextAccessor = httpContextAccessor;
  }

  public DbComment Map(CreateCommentRequest request)
  {
    return
      new()
      {
        Id = Guid.NewGuid(),
        TaskId = request.TaskId,
        CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
        CreatedAtUtc = DateTime.UtcNow,
        Content = request.CommentContent
      };
  }
}