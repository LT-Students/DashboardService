using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Models;

public record CommentInfo
{
  public Guid Id { get; set; }
  public Guid TaskId { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public string Content { get; set; }
}