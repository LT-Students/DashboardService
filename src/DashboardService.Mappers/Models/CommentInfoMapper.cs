using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Models;

public class CommentInfoMapper : ICommentInfoMapper
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public CommentInfoMapper(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

  public CommentInfo Map(DbComment dbComment)
  {
    return new()
      {
        Id = dbComment.Id,
        TaskId = dbComment.TaskId,
        CreatedBy = dbComment.CreatedBy,
        CreatedAtUtc = dbComment.CreatedAtUtc,
        Content = dbComment.Content
      };
  }
}