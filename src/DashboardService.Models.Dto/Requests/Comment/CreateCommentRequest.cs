using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;

public record CreateCommentRequest
{
  /// <summary>
  /// Unique task identifier.
  /// </summary>
  public Guid TaskId { get; set; }
  
  /// <summary>
  /// Comment content.
  /// </summary>
  public string Content { get; set; }
}