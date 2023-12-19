using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Responses;

public record CommentResponse
{
  public Guid CommentId { get; set; }
  public Guid TaskId { get; set; }
  public Guid CommentCreatedBy { get; set; }
  public DateTime CommentCreatedAtUtc { get; set; }
  public string CommentContent { get; set; }
}