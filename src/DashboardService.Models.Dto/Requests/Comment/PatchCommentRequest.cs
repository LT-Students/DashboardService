using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;

public record PatchCommentRequest
{
  public Guid TaskId { get; set; }
  public Guid CommentCreatedBy { get; set; }
  public DateTime CommentCreatedAtUtc { get; set; }
  public string CommentContent { get; set; }
}