using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;

public record CreateCommentRequest
{
  public Guid TaskId { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public string Content { get; set; }
}