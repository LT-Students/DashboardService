using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Responses;

public record CommentResponse
{
  public Guid CommentId { get; set; }
  public Guid TaskId { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public string Content { get; set; }
}