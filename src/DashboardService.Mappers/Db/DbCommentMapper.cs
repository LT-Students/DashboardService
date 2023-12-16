using LT.DigitalOffice.DashboardService.Mappers.Db.Interfaces;
using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;
using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace LT.DigitalOffice.DashboardService.Mappers.Db;

public class DbCommentMapper : IDbCommentMapper
{
  public DbComment Map(CreateCommentRequest request)
  {
    return request is null
      ? null
      : new()
      {
        Id = Guid.NewGuid(),
        TaskId = request.TaskId,
        CreatedBy = request.CommentCreatedBy,
        CreatedAtUtc = request.CommentCreatedAtUtc,
        Content = request.CommentContent
      };
  }
}