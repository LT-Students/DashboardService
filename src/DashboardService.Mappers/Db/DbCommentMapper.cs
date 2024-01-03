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
  public DbComment Map(Guid createdBy, CreateCommentRequest request)
  {
    return new()
    {
      Id = Guid.NewGuid(),
      TaskId = request.TaskId,
      CreatedBy = createdBy,
      CreatedAtUtc = DateTime.UtcNow,
      Content = request.Content
    };
  }
}