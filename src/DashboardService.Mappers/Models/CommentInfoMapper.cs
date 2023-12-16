using LT.DigitalOffice.DashboardService.Mappers.Models.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Models;

public class CommentInfoMapper : ICommentInfoMapper
{
  public CommentInfo Map(DbComment dbComment)
  {
    return dbComment is null
      ? null
      : new()
      {
        Id = dbComment.Id,
        TaskId = dbComment.TaskId,
        CreatedBy = dbComment.CreatedBy,
        CreatedAtUtc = dbComment.CreatedAtUtc,
        Content = dbComment.Content
      };
  }
}