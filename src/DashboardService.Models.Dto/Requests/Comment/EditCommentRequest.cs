using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;

public record EditCommentRequest
{
  /// <summary>
  /// New comment content.
  /// </summary>
  public string Content { get; set; }
}