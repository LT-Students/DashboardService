using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment;

public record EditCommentRequest
{
  public string Content { get; set; }
}